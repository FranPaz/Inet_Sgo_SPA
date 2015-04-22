inetApp.controller('servInstalacionCtrl', function ($scope, $state, listadoEscuelas, listadoInstaladoresRed, detalleLineaJurisSvc, dictJurisSvc) {

    //#region Inicializacion de Variables de Scope
    $scope.escuelas = listadoEscuelas; //var donde guardo el listado de escuelas para poder seleccionar cual se va a a asociar al dictamen institucional al hacer el abm    
    $scope.escuelaBuscada = {};
    $scope.instaladores = listadoInstaladoresRed;
    $scope.instaladorBuscado = {};

    $scope.detalleInstaladorRed = {}; // array que va a tener los servicios de Instalacion de Red y piso Tecnologico correspndientes a cada escuela    
    $scope.detalleInstaladorRed.Servicios = []; // array que va a tener los servicios de instaladores de red () que se van cargando como parte de un detalle de Instaladores de Red y Piso Tec

    $scope.turnos = [
        { turnoTrabajado: 'Mañana' },
        { turnoTrabajado: 'Tarde' }
    ];
    $scope.turnoBuscado = {};
    $scope.indexLinea = $state.params.prmIndexLinea;
    $scope.infoLinea = dictJurisSvc.getLineaJuris($scope.indexLinea); // traigo la linea jurisdiccional para la que le voy a cargar los detalles

    //#endregion     

    //#region Alta de Servicios de Administrador de Red
    $scope.contratoAdministrador = {}; // variable donde voy a tener los datos del administrador que voy a dar de alta       

    $scope.addAdmin = function () { //funcion para agregar un administrador y su contrato a la lista de administradores de una escuela        

        $scope.contratoAdministrador.AdministradorDeRed = $scope.adminBuscado.selected;
        $scope.contratoAdministrador.Turno = $scope.turnoBuscado.selected.turnoTrabajado;

        $scope.detalleAdminRed.EscuelaId = $scope.escuelaBuscada.selected;
        $scope.detalleAdminRed.Servicios.push($scope.contratoAdministrador);

        //limpio las variables del administrador y su contrato
        $scope.limpiarContratoAdmin();
    }
    //#endregion

    //#region Alta de Detalles Jurisdiccionales de Administradores de Red

    $scope.detalleAdd = function () { //funcion para agregar el detalle cargado al array de detalles de la linea

        var fondoAdmin = detalleLineaJurisSvc.getInfoDetalleJuris();
        fondoAdmin.EscuelaId = $scope.detalleAdminRed.EscuelaId.Id;
        fondoAdmin.Servicios = $scope.detalleAdminRed.Servicios;

        $scope.infoLinea.detalles.push(fondoAdmin);
        dictJurisSvc.addDetallesLinea($scope.indexLinea, $scope.infoLinea);
        alert("Detalle Jurisdiccional Cargado");
        detalleLineaJurisSvc.limpiarDetalleJuris();//llamo a la funcion para limpiar todos los campos usados para cargar un detalle jurisdiccional y lo dejo listo para cargar uno nuevo
    }
    //#endregion

    //#region Limpieza de campos
    $scope.limpiarContratoAdmin = function () { //funcion que limpia los campos y selects que se usan para cargar el contrato de servicio de un administrador de red para una escuela
        $scope.contratoAdministrador = {};
        $scope.adminBuscado = {};
        $scope.turnoBuscado = {};
    }

    $scope.$on('limpiarDetalles', function () { // recivo el evento definido para limpiar los campos del detalles y dejarlo limpio para cargar uno nuevo
        $scope.limpiarContratoAdmin();
        $scope.escuelaBuscada = {};
        $scope.detalleAdminRed = {};
        $scope.detalleAdminRed.Servicios = []; // array que va a tener los servicios de admin de red () que se van cargando como parte de un detalle de admin de red
    });
    //#endregion
    
});