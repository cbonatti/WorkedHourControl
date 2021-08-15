export class ErroHandler {
    public static handle(error) {
        if (error.status == 401 || error.status == 403)
            alert('Você não tem permissão para acessar esse recurso');
        else
            alert(error.error);
    }
}