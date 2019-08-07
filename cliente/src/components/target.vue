<template>
  <v-card
    class="mx-auto"
    max-width="344"
    outlined
    @click="$router.push(to)"
  >
    <v-list-item three-line>
      <v-list-item-content>
        <div class="overline mb-4">Biblioteca</div>
        <v-list-item-title class="headline mb-1">{{section}}</v-list-item-title>
        <v-list-item-subtitle>{{description}}</v-list-item-subtitle>
      </v-list-item-content>
  
      <v-list-item-avatar
        tile
        size="80"
        color="grey"
      >
        <v-img :src="icon"></v-img>
      </v-list-item-avatar>
    </v-list-item>

    <v-card-actions>
      <v-btn text @click="$router.push(to)">Ver</v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  name: 'target',
  props: {
    icon: String,
    to: String,
    section: String,
    description: String
  }
}
</script>

