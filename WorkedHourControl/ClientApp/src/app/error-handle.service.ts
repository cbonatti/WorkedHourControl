export class ErroHandler {
    public static handle(error) {
        if (error.status == 401)
            alert('Você não tem permissão para acessar esse recurso');
        else
            alert(error.error);
    }
}