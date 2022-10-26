import { useEffect, useState } from "react"
import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import ModalCliente from "./componentes/ModalCliente"
import TablaClientes from "./componentes/TablaClientes"

const App = () => {

    const [clientes, setClientes] = useState([])

    const [mostrarModal, setMostrarModal] = useState(false)
    const [editar, setEditar] = useState(null)

    const listadoClientes = async () => {
        const response = await fetch("api/cliente/Listado");

        if (response.ok) {
            const data = await response.json();
            setClientes(data)
        } else {
            console.log("Error al obtener el listado de clientes")
        }
    }

    useEffect(() => {
        listadoClientes()
    }, [])

    const guardarCliente = async (cliente) => {
        const response = await fetch("api/cliente/Nuevo", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(cliente)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            listadoClientes();
        }
    }

    const editarCliente = async (cliente) => {
        const response = await fetch("api/cliente/Editar", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(cliente)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            listadoClientes();
        }
    }

    const eliminarCliente = async (id) => {
        let respuesta = window.confirm("Desea eliminar este registro?")
        if (!respuesta) {
            return;
        }

        const response = await fetch("api/cliente/Eliminar/" + id, {
            method: 'DELETE'
        })

        if (response.ok) {
            listadoClientes();
        }
    }

    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Listado de clientes</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setMostrarModal(!mostrarModal)}>Nuevo cliente</Button>
                            <hr></hr>
                            <TablaClientes
                                data={clientes}

                                setEditar={setEditar}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}

                                eliminarCliente={eliminarCliente}
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>

            <ModalCliente
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                guardarCliente={guardarCliente}

                editar={editar}
                setEditar={setEditar}
                editarCliente={editarCliente}
            />
        </Container>
        )
}

export default App;