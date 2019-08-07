<template>
  <v-container fluid fill-height>
    <v-data-table
    :headers="headers"
    :items="books"
    sort-by="nombre"
    class="elevation-1"
    >
      <template v-slot:item.bookCategory="{ item }">
        <v-chip dark> {{ item.bookCategory | categoriesFilter }} </v-chip>
      </template>
      <template v-slot:top>
        <v-toolbar flat color="white">
          <v-toolbar-title>Libros</v-toolbar-title>
          <v-divider class="mx-4" inset vertical ></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on }">
              <v-btn dark class="mb-2" v-on="on">Agregar Libro</v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>

              <v-card-text>
                <v-container grid-list-md>
                  <v-layout wrap>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editBook.nombre" label="Nombre"></v-text-field>
                    </v-flex>
                    <v-flex xs12 sm6 md4>
                      <v-select
                        :items="autors"
                        v-model="editBook.autor"
                        return-object
                        label="Autor"
                        item-text="nombre"
                      ></v-select>
                    </v-flex>
                  </v-layout>
                  <v-layout row wrap>
                    <v-flex xs12 sm6 md4>
                      <v-select
                        label="Categorias"
                        :items="categories"
                        v-model="categoriesOnBook"
                        multiple
                        chips
                        hint="Elija la categoría"
                        persistent-hint
                        item-text="nombre"
                        return-object
                      ></v-select>
                    </v-flex>
                    <v-flex xs12 sm6 md4>
                      <v-text-field v-model="editBook.isbn" label="ISBN"></v-text-field>
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
        No hay libros registrados
      </template>
    </v-data-table>
  </v-container>
</template>
<script>

export default {
  name: 'book',
  data: () => ({
    dialog: false,
    headers: [
      { text: 'Nombre', value: 'nombre' },
      { text: 'Autor', value: 'autor.nombre' },
      { text: 'Categoria', value: 'bookCategory' },
      { text: 'ISBN', value: 'isbn' },
      { text: 'Actions', value: 'action', sortable: false }
    ],
    editedIndex: -1,
    editBook: {
      nombre: '',
      autor: {},
      bookCategory:[],
      isbn: ''
    },
    defaultBook: {
      nombre: '',
      autor: {},
      bookCategory:[],
      isbn: ''
    },
    cats: []
  }),
  methods: {
    close () {
        this.dialog = false
        setTimeout(() => {
          this.editBook = Object.assign({}, this.defaultBook)
          this.editedIndex = -1
        }, 300)
      },

      save () {
        if (this.editedIndex > -1) {
          this.editBook.bookCategory = []
          this.$store.dispatch('editBook', { book: this.editBook, categories: this.cats })
        } else {
          this.editBook.bookCategory = []  
          this.$store.dispatch('addBook', { book: this.editBook, categories: this.cats })
        }
        this.close()
      },
      editItem (item) {
        this.editedIndex = this.books.indexOf(item)
        this.editBook = Object.assign({}, item)
        this.dialog = true
      },
      deleteItem (item) {
        // const index = this.books.indexOf(item)
        // this.item.bookCategory = []
        this.$store.dispatch('delBook', item)
        // confirm('Deseas Eliminar este libro?') && this.$store.dispatch('delBook', item)
      }      
  },
  filters: {
    categoriesFilter (bookCategory) {
        var cats = ''
        if (bookCategory.length > 0) {
          bookCategory.forEach(cat => {
            cats += cat.category.nombre + " - "
          });
        }
        // categoriesList = cats
        return cats
      }
  },
  computed: {
    categories () {
      return this.$store.getters.categories
    },
    autors () {
      return this.$store.getters.autors
    },
    books () {
      return this.$store.getters.books
    },
    error () {
      return this.$store.getters.error
    },
    formTitle () {
      return this.editedIndex === -1 ? 'Nuevo Libro' : 'Editar Libro'
    },
    categoriesOnBook: {
      get () {
        var cats = []
        if (this.editBook.bookCategory.length > 0) {
          this.editBook.bookCategory.forEach(cat => {
            cats.push(cat.category)
          });
        }
        return cats
      },
      set (list) {
        this.cats = list
      }
    }
  }
}
</script>
