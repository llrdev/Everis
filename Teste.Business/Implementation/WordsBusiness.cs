using System;
using System.Text;
using Teste.Business.Base;
using Teste.Business.Dto;
using Teste.Business.Contract;

namespace Teste.Business.Implementation
{
    public class WordsBusiness : IWords
    {
        public BaseResponse<int> TransformWord(WordDTO wordsDTO)
        {
            BaseResponse<int> response = new BaseResponse<int>();

            try
            {             
                var res = FindWordsInWords(wordsDTO);
                if ( res == -1)
                {
                    response.status = new Message(MessageType.ERRO, "No Match") ;
                    return response;
                }
                else
                {
                    response.Response = res;
                    response.status = new Message(MessageType.SUCCESS, "Match");
                }
                
            }
            catch (Exception ex)
            {
                response.status = new Message(MessageType.ERRORSERVER, ex.Message);
                return response;
            }
            
            return response;
        }

        private int FindWordsInWords(WordDTO wordsDTO)
        {
            int response = 0;

            string wordOne = wordsDTO.WordOne;
            string wordTwo = wordsDTO.WordTwo;

            string wordStart = "";
            string wordOneReplace = "";

            if (wordOne.Length > wordTwo.Length)
            {
                int indiceRemove = wordOne.Length - wordTwo.Length;
                wordStart = wordOne.Remove(0, indiceRemove);
                response = indiceRemove;
            }
            else if(wordOne.Length < wordTwo.Length)
            {
                return -1;
            }
            else
            {
                wordStart = wordOne;
            }

            StringBuilder sb = new StringBuilder(wordStart);

            for (int i = 0; i < wordStart.Length; i++)
            {
                if (sb[i] != wordTwo[i])
                {
                    sb[i] = wordTwo[i];
                    wordOneReplace = sb.ToString();

                    response++;
                }
            }

            return response;
        }
    }
}
