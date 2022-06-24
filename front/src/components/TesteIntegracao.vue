<template>
    <div>
        <div v-if="!carregando">

            <div :key="index" v-for="(personagem, index) in personagens" :personagem="personagem">
                <v-row>
                    <v-col>
                        Esse é o nome {{ personagem.nome }}
                    </v-col>
                    <v-col>
                        Essa é a franquia {{ personagem.franquia }}
                    </v-col>
                </v-row>
            </div>
        </div>
        <div v-else class="center">Carregando...</div>
    </div>
</template>

<script>
import { listarPersonagens } from "../service/postService.js";

export default {
    name: 'TesteIntegracao',
    components: {

    },
    data: () => {
        return {
            novoPersonagem: {
                nome: '',
                franquia: '',
            },
            personagens: [],
            carregando: true,
        };
    },
    async mounted() {
        this.personagens = await this.carregarPersonagens();
    },
    methods: {
        carregarPersonagens() {
            listarPersonagens().then((personagens) => {
                this.carregando = false;
                this.personagens = personagens;
            });
        },
    }
}
</script>

<style>
</style>