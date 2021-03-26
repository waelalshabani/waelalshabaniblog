using System;

namespace WaelAlshabaniBlog.Core.Domain
{
    public record TrackingInformation<TUserId> where TUserId : struct
    {

        #region readonly fields

        private readonly TUserId _operationMadeBy;
        private readonly TrackingInformationOperationType _operationType;

        #endregion

        #region public properties

        public TUserId CreatedByUserId { get; private set; }
        public DateTimeOffset CreatedAtDateTime { get; private set; }

        public TUserId? LastModifiedByUserId { get; private set; }
        public DateTimeOffset? LastModifiedAtDateTime { get; private set; }
        public int ModificationVersion { get; private set; }

        public TUserId? DeletedByUserId { get; private set; }
        public DateTimeOffset? DeletedAtDateTime { get; private set; }

        #endregion

        #region Private constructor

        private TrackingInformation(TrackingInformationOperationType operationType, TUserId operationMadeBy)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            _operationMadeBy = operationMadeBy;
            _operationType = operationType;

            switch (_operationType)
            {
                case TrackingInformationOperationType.Modification:
                    LastModifiedByUserId = _operationMadeBy;
                    LastModifiedAtDateTime = now;
                    ModificationVersion += 1;
                    break;
                case TrackingInformationOperationType.Deletion:
                    DeletedByUserId = _operationMadeBy;
                    DeletedAtDateTime = now;
                    break;
                case TrackingInformationOperationType.Creation:
                    CreatedByUserId = _operationMadeBy;
                    CreatedAtDateTime = now;
                    break;
                default:
                    throw new InvalidOperationException("You should set explicit tracking information operation type");
            }
        }

        #endregion



        public static TrackingInformation<TUserId> Create(TrackingInformationOperationType operationType, TUserId operationMadeBy)
        {
            return new TrackingInformation<TUserId>(operationType, operationMadeBy);
        }


        public string GetRecordModificationInfo(Func<TUserId, string> madeByUserInfoCallback = null)
        {
            var modification = ModificationVersion switch
            {
                0 => $"has not been modified yet",
                1 => $"has {ModificationVersion} modification",
                _ => $"has {ModificationVersion} modifications"
            };

            var timeOfModification = ModificationVersion switch
            {
                0 => $"",
                1 => $" and was modified at {LastModifiedAtDateTime}",
                _ => $" and last one was made at {LastModifiedAtDateTime}"
            };

            /*
             * Note to myself:
             * LastModifiedByUserId don't need to check for nullability here, if ModificationVersion 
             * is more than zero then it's a must that LastModifiedByUserId has a value.
             * If there was no value then there's a bug in the system!
             */

            var userInformation = ModificationVersion switch
            {
                0 => $"",
                _ => $"by {GetUserInfo(madeByUserInfoCallback, LastModifiedByUserId.Value)}"
            };

            return $"This record {modification}{timeOfModification}{userInformation}.";
        }





        public string GetRecordCreationInfo(Func<TUserId, string> madeByUserInfoCallback = null)
        {
            return $"This record was created at {CreatedAtDateTime}{GetUserInfo(madeByUserInfoCallback, CreatedByUserId)}.";
        }





        public string GetRecordDeletionInfo(Func<TUserId, string> madeByUserInfoCallback = null)
        {
            if (DeletedByUserId is null && DeletedAtDateTime is null)
            {
                return $"This record is active, no one has deleted it yet!";
            }

            return $"This record was deleted at {DeletedAtDateTime}{GetUserInfo(madeByUserInfoCallback, CreatedByUserId)}.";
        }


        #region ToString override

        public override string ToString()
        {
            return $"Creation information: \n{GetRecordCreationInfo()}\n" +
                $"Modification information:\n{GetRecordModificationInfo()}\n" +
                $"Deletion information: \n{GetRecordDeletionInfo()}\n\n";
        }

        #endregion

        #region Private helper methods

        private string GetUserInfo(Func<TUserId, string> madeByUserInfoCallback, TUserId userId)
        {
            var userInformation = madeByUserInfoCallback?.Invoke(userId);

            if (madeByUserInfoCallback is null || string.IsNullOrEmpty(userInformation))
            {
                userInformation = $"by user id: {userId}";
            }

            return userInformation;
        }

        #endregion

    }
}
