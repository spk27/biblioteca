<template>
  <v-footer
    height="auto"
  >
    <v-card
      class="flex"
      flat
      tile
    >
      <v-card-actions class="">
            
        <v-btn href="https://github.com/spk27" target="_blank" class="mx-3" icon >
          <v-icon size="24px">{{ github }}</v-icon>
        </v-btn>
        <v-btn href="https://twitter.com/daguilardev" target="_blank" class="mx-3" icon >
          <v-icon size="24px">{{ twitter }}</v-icon>
        </v-btn>
        <v-btn href="https://linkedin.com/in/dhal27" target="_blank" class="mx-3" icon >
          <v-icon size="24px">{{ linkedin }}</v-icon>
        </v-btn>
        <v-spacer></v-spacer>
        <span class="mr-3 hidden-xs-only"><strong >dhaguilar27@gmail.com</strong></span>
      </v-card-actions>
    </v-card>
  </v-footer>
</template>

<script>
  export default {
    name: 'AppFooter',
    data: () => ({
      github: 'mdi-github-face',
      twitter: 'mdi-twitter',
      linkedin: 'mdi-linkedin',
      instagram: 'mdi-instagram',
      icons: [
        'mdi-twitter',
        'mdi-google-plus',
        'mdi-linkedin',
        'mdi-instagram'
      ]
    })
  }
</script>