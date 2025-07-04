﻿namespace FileValidation.Module.Validators.ArchiveFiles
{
    public class RarValidator : IFileValidator
    {
        public (bool, string) Validate(byte[] buffer)
        {
            bool validation = buffer.Length >= 7 &&
               buffer[0] == 0x52 &&
               buffer[1] == 0x61 &&
               buffer[2] == 0x72 &&
               buffer[3] == 0x21 &&
               buffer[4] == 0x1A &&
               buffer[5] == 0x07 &&
               buffer[6] == 0x00;

            return (validation, "rar");
        }
    }
}