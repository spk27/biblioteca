<template>
  <v-container grid-list-xs>
    <v-layout row wrap>
      <v-flex md4>
        <target to="book" section="Libros" description="Sección de librería" icon="https://2.bp.blogspot.com/-8Ww_guqX7us/UMigbAmT6aI/AAAAAAAAASE/b-B6zJ6pbbA/s1600/Books-1-icon.png"></target>
      </v-flex>
      <v-flex md4>
        <target to="category" section="Categorias" description="Sección de categorias" icon="https://pngimage.net/wp-content/uploads/2018/05/category-png-5.png"></target>
      </v-flex>
      <v-flex md4>
        <target to="autor" section="Autores" description="Sección de Autores" icon="https://www.ecured.cu/images/e/e7/Autor2.jpeg"></target>
      </v-flex>
    </v-layout>
    <br/>
    <v-divider></v-divider>
    <br/>
    <v-layout row wrap>
      <v-flex md6 offset-md3>
        <v-text-field v-model="searching" placeholder="Buscar libro por nombre, categoria, autor o ISBN" solo append-icon="mdi-magnify"></v-text-field>
      </v-flex>
    </v-layout>
    <!-- <v-layout row wrap>
      {{$store.getters.books}}
    </v-layout> -->
    <v-layout row wrap>
      <v-data-iterator v-if="filterBooks.length > 0 || searching"
        :items="filterBooks"
        :options="pagination"
        content-tag="v-layout"
        row
        wrap
      >
        <v-alert justify-center slot="no-data" :value="true" color="black" dark icon="mdi-alert-box">
          Sin resultados de busqueda
        </v-alert>
        <template v-slot:default="props">
          <v-layout wrap>
          <v-flex v-for="item in props.items" :key="item.bookId"
            xs12 sm6 md6 lg6 >
            <v-card>
              <v-card-title><h4>{{ item.nombre }}</h4></v-card-title>
              <v-divider></v-divider>
              <v-list dense>
                <v-list-item>
                  <v-list-item-content>ISBN:</v-list-item-content>
                  <v-list-item-content class="align-end">{{ item.isbn }}</v-list-item-content>
                </v-list-item>
                <v-list-item>
                  <v-list-item-content>Autor:</v-list-item-content>
                  <v-list-item-content class="align-end">{{ item.autor.nombre }} - {{ item.autor.apellidos }}</v-list-item-content>
                </v-list-item>
                <v-list-item>
                  <v-list-item-content>Categorias:</v-list-item-content>
                  <v-list-item-content class="align-end">
                    <v-chip v-for="cat in item.bookCategory" :key="cat.bookCategoryId">
                      {{ cat.category.nombre }}
                    </v-chip>
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-card>
          </v-flex>
        </v-layout>
        </template>
        <template slot="pageText" slot-scope="props">
          {{ props.pageStart }} - {{ props.pageStop }} de {{ props.itemsLength }}
        </template>
      </v-data-iterator>
    </v-layout>
  </v-container>
</template>

<script>
import target from './target'
export default {
  name: 'Biblioteca',
  components: {
    target
  },
  data: () => ({
    searching: '',
    pagination: {
      rowsPerPage: 20
    }
  }),
  computed: {
    books () {
      return this.$store.getters.books
    },
    filterBooks () {
      const search = this.searching.toUpperCase()
      return this.books.filter((book) => 
        book.nombre.toUpperCase().includes(search) 
        || 
        book.isbn.toUpperCase().includes(search) 
        || 
        book.bookCategory.some(c => c.category.nombre.toUpperCase().includes(search))
        ||
        book.autor.nombre.toUpperCase().includes(search)
        ||
        book.autor.apellidos.toUpperCase().includes(search)
      )
    }
  }
}
</script>

<style scoped>
</style>
