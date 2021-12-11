
const e = React.createElement;

const ReactComponent = () => {
    const [data, setData] = React.useState({ description: '', currencyCode: 1, cuentaCR: '', cuentaDB: '', amountCR:'', amountDB:'' });
    const MONEDAS = [{ name: "Peso", value: 1 }, { name: "Dollar", value: 2 }, { name: "Euro", value: 3 }];
    const [errorMessage, setErrorMessage] = React.useState("");
    const [sending, setSending] = React.useState(false);

    async function sendData(event, datos) {
        try {
            event.preventDefault();
            setSending(true);
            let { description, currencyCode, cuentaDB, cuentaCR, amountCR, amountDB } = datos;
            let asiento = {
                description,
                auxiliar: 5,
                currencyCode,
                detail: {
                    cuentaCR,
                    cuentaDB,
                    amountDB,
                    amountCR
                }
            }
            console.log(asiento);
            let options = {
                method: "POST",
                body: JSON.stringify(asiento),
                mode: "cors",
                cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
                credentials: "same-origin", // include, *same-origin, omit
                headers: {
                    "Content-Type": "application/json",
                },
                redirect: "manual", // manual, *follow, error
                referrerPolicy: "no-referrer",
            };

            let res = await fetch("https://accountingaccountapi20211205021409.azurewebsites.net/api/AccountingSeat/Register", options);

            if (res.ok) {
                const jsonResponse = await res.json();
                setErrorMessage(`El numero del asiento generado es ${jsonResponse.id}`);
                let asiento2 = {
                    Id: 0, Id_Asiento: jsonResponse.id, Descripcion: description, Cliente_ID: parseInt(document.getElementById("clienteId").value),
                    CuentaDB: cuentaDB, CuentaCR: cuentaCR, MontoDB: amountDB, MontoCR: amountCR
                }
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: `{asientos:${JSON.stringify(asiento2)}}`,
                    url: "/Asientos/Create",
                    success: function (data) {
                        window.location.href = "/Asientos"
                    },
                    error: function (result) {
                        console.log(result)
                    }
                })
            }
            else {
                setSending(false);
                const error = await res.text();
                setErrorMessage(error);
            }        
        }
        catch (error) {
            console.error(error);
        }
    }
    return (
        <form onSubmit={(e) => sendData(e, data)}>
            <p className="has-error">{errorMessage}</p>
            <label className="control-label">Descripcion</label>
            <input required type="text" onChange={(e) => setData({ ...data, description: e.target.value })} className="form-control" value={data.description}/>

            <label className="control-label">Modena</label>
            <select value={data.currencyCode} onChange={(e) => setData({ ...data, currencyCode: parseInt(e.target.value) })} className="form-control">
                {MONEDAS.map(modena => <option key={modena.name} value={modena.value}>{modena.name}</option>)}
            </select>

            <label className="control-label">Cuenta Debito</label>
            <input required type="text" onChange={(e) => setData({ ...data, cuentaDB: e.target.value })} className="form-control" value={data.cuentaDB} />

            <label className="control-label">Cuenta Credito</label>
            <input required type="text" onChange={(e) => setData({ ...data, cuentaCR: e.target.value })} className="form-control" value={data.cuentaCR} />

            <label className="control-label">Monto Debito</label>
            <input required type="number" onChange={(e) => setData({ ...data, amountDB: parseInt(e.target.value) })} className="form-control" value={data.amountDB} />

            <label className="control-label">Monto Credito</label>
            <input required type="number" onChange={(e) => setData({ ...data, amountCR: parseInt(e.target.value) })} className="form-control" value={data.amountCR} />
            <br/>
            <button className="btn btn-default" disabled={sending}>{sending ? "Creando, espere..." : "Crear"}</button>
        </form>
    )

}

const domContainer = document.querySelector('#hola');
ReactDOM.render(e(ReactComponent), domContainer);