<template>
  <v-container fluid fill-height>
    <v-data-table
    :headers="headers"
    :items="categories"
    sort-by="nombre"
    class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-toolbar-title>Categorias</v-toolbar-title>
          <v-divider class="mx-4" inset vertical ></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on }">
              <v-btn dark class="mb-2" v-on="on">Agregar Categoria</v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>

              <v-card-text>
                <v-container grid-list-md>
                  <v-layout wrap>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editCategory.nombre" label="Nombre"></v-text-field>
                    </v-flex>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editCategory.descripcion" label="Descripcion"></v-text-field>
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
        No hay categorias registradas
      </template>
    </v-data-table>
  </v-container>
</template>
<script>

export default {
  name: 'category',
  data: () => ({
    dialog: false,
    headers: [
      { text: 'Nombre', value: 'nombre' },
      { text: 'Descripcion', value: 'descripcion' },
      { text: 'Actions', value: 'action', sortable: false }
    ],
    editedIndex: -1,
    editCategory: {
      nombre: '',
      descripcion: ''
    },
    dafaultCategory: {
      nombre: '',
      descripcion: ''
    }
  }),
  methods: {
    close () {
        this.dialog = false
        setTimeout(() => {
          this.editCategory = Object.assign({}, this.dafaultCategory)
          this.editedIndex = -1
        }, 300)
      },

      save () {
        if (this.editedIndex > -1) {
          this.$store.dispatch('editCategory', this.editCategory)
          // Object.assign(this.desserts[this.editedIndex], this.editCategory)
        } else {
          this.$store.dispatch('addCategory', this.editCategory)
          // this.desserts.push(this.editCategory)
        }
        this.close()
      },
      editItem (item) {
        this.editedIndex = this.categories.indexOf(item)
        this.editCategory = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        // const index = this.categories.indexOf(item)
        console.log(item)
        this.$store.dispatch('delCategory', item)
        // confirm('Deseas Eliminar esta categoría?') && this.$store.dispatch('delCategory', item)
      },
  },
  computed: {
    categories () {
      return this.$store.getters.categories
    },
    error () {
      return this.$store.getters.error
    },
    formTitle () {
      return this.editedIndex === -1 ? 'Nueva Categoria' : 'Editar Categoria'
    }
  }
}
</script>
