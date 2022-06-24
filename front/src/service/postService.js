import axios from 'axios';

const apiUrlBase = 'https://localhost:7288/api';

export function listarPersonagens() {
  return axios.get(`${apiUrlBase}/Personagens`).then((response) => {
    const personagem = response.data;
    return personagem?.map((personagem) => {
      return {
        nome: personagem.nome,
        franquia: personagem.franquia,
      };
    });
  });
}
