using System;
using System.Collections.Generic;
using SecureHashAlgorithms;

namespace BlockChain
{
    public class Block
    {
        int _blockId;
        int _nonce;
        string _message;
        byte[] _previousHash;
       

        public Block(int blockId, string message, byte[] previousHash)
        {
            _blockId = blockId;
            _nonce = 0;
            _message = message;
            _previousHash = previousHash;
        }


        public byte[] GetBlockBytes()
        {
            List<byte> B = new List<byte>();
            B.AddRange(ShaUtil.StringToByteArray(_blockId.ToString()));
            B.AddRange(ShaUtil.StringToByteArray(_nonce.ToString()));
            B.AddRange(ShaUtil.StringToByteArray(_message));
            B.AddRange(_previousHash);

            return B.ToArray();
        }


        public byte[] CalculateHash()
        {
            return Sha.Sha256(GetBlockBytes());
        }


        public bool IsBlockSigned()
        {
            // The block being signed is defined to mean that its hash begins with four zeros (in hex).
            // This is equivalent to saying that the first two bytes of the hash are zero.
            byte[] hash = CalculateHash();

            return ((hash[0] == 0) && (hash[1] == 0));
        }


        public bool MineNonce()
        {
            for (int n = 0; n < 500000; n++)
            {
                SetNonce(n);
                byte[] hash = CalculateHash();

                if (IsBlockSigned())
                {
                    return true;
                }
            }

            return false;
        }
        

        public void SetNonce(int nonce)
        {
            _nonce = nonce;
        }


        public int GetNonce()
        {
            return _nonce;
        }


        public byte[] GetPreviousHash()
        {
            return _previousHash;
        }


        public string PreviousHashToHexString()
        {
            return ShaUtil.ByteArrayToHexString(_previousHash);
        }


        public string HashToHexString()
        {
            return ShaUtil.ByteArrayToHexString(CalculateHash());
        }



    }
}
