using System;
using System.Collections.Generic;
using Teste.Business.Base;
using Teste.Business.Contract;
using Teste.Business.Dto;
using Teste.Business.Implementation;
using Xunit;

namespace Teste.Xunit
{
    public class WordsInWordsTest
    {
        

        public WordsInWordsTest()
        {
           
        }

        [Fact]
        public void TestWordsInWordsMatch()
        {
            WordsBusiness wordsBusiness = new WordsBusiness();

            WordsMock1 mock = new WordsMock1();

            foreach (var item in mock.WordDTOList)
            {
                var res = wordsBusiness.TransformWord(item);

                Assert.NotEqual(-1, res.Response);
            }
        }

        [Fact]
        public void TestWordsInWordsNoMatch()
        {
            WordsBusiness wordsBusiness = new WordsBusiness();

            WordsMock2 mock = new WordsMock2();

            foreach (var item in mock.WordDTOList)
            {
                var res = wordsBusiness.TransformWord(item);

                Assert.Equal(MessageType.ERRO, res.status.Code);
            }
        }
    }

    public class WordsMock1
    {
        public List<WordDTO> WordDTOList { get; set; }

        public WordsMock1()
        {
            WordDTOList = new List<WordDTO>();
            WordDTO wordDTO = null;

            wordDTO = new WordDTO();
            wordDTO.WordOne = "Absorver";
            wordDTO.WordTwo = "absolver";            
            WordDTOList.Add(wordDTO);

            wordDTO = new WordDTO();
            wordDTO.WordOne = "Aferir";
            wordDTO.WordTwo = "auferir";
            WordDTOList.Add(wordDTO);

            wordDTO = new WordDTO();
            wordDTO.WordOne = "Cavaleiro";
            wordDTO.WordTwo = "cavalheiro";
            WordDTOList.Add(wordDTO);

            wordDTO = new WordDTO();
            wordDTO.WordOne = "Dirigente";
            wordDTO.WordTwo = "diligente";
            WordDTOList.Add(wordDTO);

            wordDTO = new WordDTO();
            wordDTO.WordOne = "Discriminar";
            wordDTO.WordTwo = "descriminar";
            WordDTOList.Add(wordDTO);

            wordDTO = new WordDTO();
            wordDTO.WordOne = "Estofar";
            wordDTO.WordTwo = "estufar";
            WordDTOList.Add(wordDTO);
        }
    }

    public class WordsMock2
    {
        public List<WordDTO> WordDTOList { get; set; }

        public WordsMock2()
        {
            WordDTOList = new List<WordDTO>();
            WordDTO wordDTO = null;

            wordDTO = new WordDTO();
            wordDTO.WordOne = "vazio";
            wordDTO.WordTwo = "naovazio";
            WordDTOList.Add(wordDTO);

            wordDTO = new WordDTO();
            wordDTO.WordOne = "cheio";
            wordDTO.WordTwo = "naocheio";
            WordDTOList.Add(wordDTO);

            
        }
    }
}
