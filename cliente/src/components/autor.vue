<template>
  <v-container fluid fill-height>
    <v-data-table
    :headers="headers"
    :items="autors"
    sort-by="nombre"
    class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-toolbar-title>Autores</v-toolbar-title>
          <v-divider class="mx-4" inset vertical ></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on }">
              <v-btn dark class="mb-2" v-on="on">Agregar Autor</v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>

              <v-card-text>
                <v-container grid-list-md>
                  <v-layout wrap>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editAutor.nombre" label="Nombre"></v-text-field>
                    </v-flex>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editAutor.apellidos" label="Apellidos"></v-text-field>
                    </v-flex>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editAutor.fechaNacimiento" type="date" label="Fecha de Nacimiento"></v-text-field>
                    </v-flex>
                  </v-layout>
                </v-container>
              </v-card-text>

              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="close">Cerrar</v-btn>
                <v-btn color="blue darken-1" text @click="save">Guardar</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <template v-slot:item.action="{ item }">
        <v-icon small class="mr-2"  @click="editItem(item)" >mdi-pencil</v-icon>
        <v-icon small @click="deleteItem(item)" >mdi-delete</v-icon>
      </template>
      <template v-slot:no-data>
        No hay autores registrados
      </template>
    </v-data-table>
  </v-container>
</template>
<script>

export default {
  name: 'autor',
  data: () => ({
    dialog: false,
    headers: [
      { text: 'Nombre', value: 'nombre' },
      { text: 'Apellidos', value: 'apellidos' },
      { text: 'Fecha de Nacimiento', value: 'fechaNacimiento' },
      { text: 'Actions', value: 'action', sortable: false }
    ],
    editedIndex: -1,
    editAutor: {
      nombre: '',
      apellidos: '',
      fechaNacimiento: ''
    },
    dafaultAutor: {
      nombre: '',
      apellidos: '',
      fechaNacimiento: ''
    }
  }),
  methods: {
    close () {
        this.dialog = false
        setTimeout(() => {
          this.editAutor = Object.assign({}, this.dafaultAutor)
          this.editedIndex = -1
        }, 300)
      },

      save () {
        if (this.editedIndex > -1) {
          this.$store.dispatch('editAutor', this.editAutor)
          // Object.assign(this.desserts[this.editedIndex], this.editAutor)
        } else {
          this.$store.dispatch('addAutor', this.editAutor)
          // this.desserts.push(this.editAutor)
        }
        this.close()
      },
      editItem (item) {
        this.editedIndex = this.autors.indexOf(item)
        this.editAutor = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        // const index = this.autors.indexOf(item)
        console.log(item)
        this.$store.dispatch('delAutor', item)
        // confirm('Deseas Eliminar este autor?') && this.$store.dispatch('delAutor', item)
      },
  },
  computed: {
    autors () {
      return this.$store.getters.autors
    },
    error () {
      return this.$store.getters.error
    },
    formTitle () {
      return this.editedIndex === -1 ? 'Nuevo Autor' : 'Editar Autor'
    }
  }
}
</script>
