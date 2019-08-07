<template>
  <v-container grid-list-xs>
    <v-layout row wrap>
      <v-flex md6 offset-md3>
        <v-text-field v-model="searching" placeholder="Buscar libro" solo append-icon="search"></v-text-field>
      </v-flex>
    </v-layout>
    <!-- <v-layout row wrap>
      {{$store.getters.books}}
    </v-layout> -->
    <v-layout row wrap>
      <v-data-iterator v-if="filterBooks.length > 0 || searching"
        :items="filterBooks"
        :rows-per-page-items="[6,12,20]"
        :pagination.sync="pagination"
        rows-per-page-text="Libros por página"
        content-tag="v-layout"
        row
        wrap
      >
        <v-alert slot="no-data" :value="true" color="black" dark icon="warning">
          Sin resultados de busqueda
        </v-alert>
        <template slot="item" slot-scope="props">
          <v-flex xs6 sm4 md3 lg2 pa-1>
            {{props.item.nombre}}
          </v-flex>
        </template>
        <template slot="pageText" slot-scope="props">
          {{ props.pageStart }} - {{ props.pageStop }} de {{ props.itemsLength }}
        </template>
      </v-data-iterator>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  name: 'Biblioteca',
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
      return this.books.filter((book) => 
        book.nombre.toUpperCase().includes(this.searching.toUpperCase()) 
        || 
        book.category.toUpperCase().includes(this.searching.toUpperCase())
        ||
        book.autor.toUpperCase().includes(this.searching.toUpperCase())
      )
    }
  }
}
</script>

<style scoped>
</style>
