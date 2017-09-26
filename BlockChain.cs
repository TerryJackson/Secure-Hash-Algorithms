using System;
using System.Collections.Generic;
using SecureHashAlgorithms;

namespace BlockChain
{
    public class BlockChain
    {
        List<Block> _blocks;

        public BlockChain()
        {
            _blocks = new List<Block>();
        }

        public bool IsBlockChainSigned()
        {
            // The blockchain being signed means:
            
            // 1. The blockchain is nonempty.
            if (_blocks.Count == 0)
            {
                return false;
            }

            // 2. Each block is signed (the hash of the block begins with four zeros).
            for (int i = 0; i < NumberBlocks(); i++)
            {
                if (!_blocks[i].IsBlockSigned())
                {
                    return false;
                }
            }

            // 3. Each block except the first has its previous hash field equal to the hash of the previous block.
            for (int i = 1; i < NumberBlocks(); i++)
            {
                if (ShaUtil.ByteArraysEqual(_blocks[i].GetPreviousHash(), _blocks[i].CalculateHash()))
                {
                    return false;
                }
            }

            return true;
        }


        public int NumberBlocks()
        {
            return _blocks.Count;
        }



    }
}
