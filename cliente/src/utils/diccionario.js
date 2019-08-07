const dict = {
  custom: {
    userName: {
      required: 'Debe indicar el nombre de usuario',
      alpha_dash: 'El nombre de usuario no debe contener caracteres especiales ni espacios',
      max: 'Máximo 25 caracteres'
    },
    code: {
      required: 'Debe introducir el codigo enviado',
      max: 'Código inválido',
      number: 'Sólo numeros'
    },
    correo: {
      required: 'El correo es obligatorio',
      email: 'Debe ser una dirección de correo válido',
      max: 'Direccion de correo muy largo',
      min: 'Debe ser un correo valido'
    },
    contra: {
      required: 'La contraseña es Obligatoria',
      is_not: 'La nueva contraseña debe ser distinta a la anterior',
      min: 'La contraseña debe poseer minimo 6 caracteres',
      max: 'La contraseña debe poseer maximo 100 caracteres'
    },
    oldContra: {
      required: 'La contraseña actual es Obligatoria',
      min: 'La contraseña debe poseer minimo 6 caracteres',
      max: 'La contraseña debe poseer maximo 100 caracteres'
    },
    repContra: {
      required: 'Repetir la contraseña es Obligatorio',
      confirmed: 'Las contraseñas deben coincidir',
      is: 'Las contraseñas deben coincidir',
      min: 'La contraseña debe poseer minimo 6 caracteres',
      max: 'La contraseña debe poseer maximo 100 caracteres'
    },
    terms: {
      required: 'Es obligatorio aceptar los terminos de privacidad'
    },
    telefono: {
      alpha_dash: 'El numero de telefonico no debe contener Simbolos',
      max: 'Excede el límite de caracteres permitidos'
    },
    phone: {
      required: 'Indique su número de teléfono'
    },
    codPostal: {
      required: 'El codigo postal es obligatorio',
      numeric: 'El codigo postal debe ser numerico'
    },
    Estado: {
      required: 'Debe indicar el Estado o Provincia',
      alpha_spaces: 'El estado debe contener solo letras y/o espacios'
    },
    calle: {
      required: 'Indique calle de la direccion',
      max: 'Excede el límite de caracteres permitidos'
    },
    NumExterior: {
      required: 'Indique numero del exterior',
      max: 'Excede el límite de caracteres permitidos'
    },
    descripcion: {
      required: 'Indique el Nombre o Descripcion',
      max: 'Excede el límite de caracteres permitidos'
    },
    refNumber: {
      numeric: 'Sólo números',
      required: 'Debe indicar numero de referencia de la transferencia',
      max: 'Número muy largo',
      min: 'Indique número de referencia válido'
    },
    cantidad: {
      decimal: 'Solo numeros',
      required: 'Indique la Cantidad',
      min_value: 'Debe indicar la Cantidad o Volumen'
    },
    codigo: {
      max: 'Código muy largo'
    },
    precio: {
      decimal: 'Decimales hasta dos dígitos',
      required: 'Caculo puesto manualmente: Indique el precio en Bolivares'
    },
    precioMayor: {
      decimal: 'Decimales hasta dos dígitos',
      required: 'Caculo puesto manualmente: Indique el precio en Bolivares'
    },
    producto: {
      required: 'Indique el nombre del producto',
      max: 'Nombre muy largo'
    },
    preciousd: {
      decimal: 'Decimales hasta dos dígitos',
      required: 'Indique el valor del producto en USD'
    },
    company: {
      required: 'Indique nombre de la Empresa',
      min: 'Muy pocos caracteres',
      max: 'Nombre muy largo',
      alpha_spaces: 'No se permiten caracteres especiales'
    }
  }
}

export {
  dict
}
