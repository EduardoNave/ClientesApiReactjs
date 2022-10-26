import { Table, Button } from "reactstrap"

const TablaClientes = ({ data, setEditar, mostrarModal, setMostrarModal, eliminarCliente }) => {

    const enviarDatos = (cliente) => {
        //Para almacenar la info del cliente a editar
        setEditar(cliente)
        setMostrarModal(!mostrarModal)
    }

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>Nombres</th>
                    <th>Apellidos</th>
                    <th>Telefono</th>
                    <th>TipoDocumento</th>
                    <th>NumeroDocumento</th>
                    <th>Fecha de Registro</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="7">No hay registros</td>
                        </tr>
                    ) : (
                        data.map((item) => (
                            <tr key={item.idCliente}>
                                <td>{item.nombres}</td>
                                <td>{item.apellidos}</td>
                                <td>{item.telefono}</td>
                                <td>{item.idTipoDocumento ?? "-"}</td>
                                <td>{item.numeroDocumento ?? "-"}</td>
                                <td>{item.creacion}</td>
                                <td>
                                    <Button color="primary" size="sm" className="me-2" onClick={() => enviarDatos(item)}>Editar</Button>
                                    <Button color="danger" size="sm" onClick={() => eliminarCliente(item.idCliente)}>Eliminar</Button>
                                </td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </Table>
    )
}

export default TablaClientes;