import { useEffect, useState } from "react"
import { Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input, Button } from "reactstrap"

const modeloCliente = {
    idCliente: 0,
    nombres: "",
    apellidos: "",
    telefono: "",
    //idTipoDocumento: "",
    //numeroDocumento: ""
}

const ModalCliente = ({ mostrarModal, setMostrarModal, guardarCliente, editar, setEditar, editarCliente }) => {

    const [cliente, setCliente] = useState(modeloCliente);

    const actualizarDatos = (e) => {
        setCliente(
            {
                ...cliente,
                [e.target.name]: e.target.value
            }
        )
    }

    const enviarDatos = () => {
        if (cliente.idCliente == 0) {
            // Nuevo contacto
            guardarCliente(cliente)
        } else {
            editarCliente(cliente)
        }

        setCliente(modeloCliente)
    }

    useEffect(() => {
        if (editar != null) {
            setCliente(editar)
        } else {
            setCliente(modeloCliente)
        }
    }, [editar])

    const cerrarModal = () => {
        setMostrarModal(!mostrarModal)
        setEditar(null)
    }

    return (
        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {cliente.IdCliente == 0 ? "Nuevo Cliente" : "Editar Cliente"}
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombres</Label>
                        <Input name="nombres" onChange={(e) => actualizarDatos(e)} value={cliente.nombres} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Apellidos</Label>
                        <Input name="apellidos" onChange={(e) => actualizarDatos(e)} value={cliente.apellidos} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Teléfono</Label>
                        <Input name="telefono" onChange={(e) => actualizarDatos(e)} value={cliente.telefono} />
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" className="me-2" onClick={enviarDatos}>Guardar</Button>
                <Button color="danger" size="sm" onClick={cerrarModal}>Cerrar</Button>
            </ModalFooter>
        </Modal>
    )
}

export default ModalCliente;