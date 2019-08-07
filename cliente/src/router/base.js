let baseUrl = ''
if (process.env.NODE_ENV === 'production') {
  baseUrl = 'http://localhost:8081'
} else {
  baseUrl = 'http://localhost:8081'
}

export default baseUrl
