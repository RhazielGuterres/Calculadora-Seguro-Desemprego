$(document).ready(function () {
    new Inputmask("currency", {
        prefix: "R$ ",
        groupSeparator: ".",
        radixPoint: ",",
        alias: "numeric",
        autoGroup: true,
        digits: 2,
        digitsOptional: false,
        placeholder: "0",
        rightAlign: false,
        removeMaskOnSubmit: true
    }).mask("#ultimoSalario, #penultimoSalario, #antepenultimoSalario");
});

async function calcularSeguroDesemprego() {
    const ultimoSalario = parseFloat(document.getElementById('ultimoSalario').value.replace('R$', '').replace(/\./g, '').replace(',', '.'));
    const penultimoSalario = parseFloat(document.getElementById('penultimoSalario').value.replace('R$', '').replace(/\./g, '').replace(',', '.'));
    const antepenultimoSalario = parseFloat(document.getElementById('antepenultimoSalario').value.replace('R$', '').replace(/\./g, '').replace(',', '.'));
    const mesesTrabalhados = parseInt(document.getElementById('mesesTrabalhados').value);
    const vezesSolicitado = parseInt(document.getElementById('vezesSolicitado').value);

    const data = {
        ultimoSalario: ultimoSalario,
        penultimoSalario: penultimoSalario,
        antepenultimoSalario: antepenultimoSalario,
        mesesTrabalhados: mesesTrabalhados,
        vezesSolicitado: vezesSolicitado
    };

    try {
        const response = await fetch('/api/CalculoSalario/calcularSeguroDesemprego', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Erro na requisição');
        }

        const resultado = await response.json();
        document.getElementById('modalBody').innerHTML = `
            <table class="result-table">
                <thead>
                    <tr>
                        <th>Eventos</th>
                        <th>Valores</th>
                        <th>Parcelas</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Seguro-Desemprego</td>
                        <td class="highlight">R$ ${resultado.parcela.toFixed(2)}</td>
                        <td class="highlight">${resultado.parcelas}</td>
                    </tr>
                </tbody>
            </table>
            <br></br>
            <h5>Faixas salariais para cálculo do seguro-desemprego em 2024</h5>
            <table class="info-table">
                <thead>
                    <tr>
                        <th>Faixas de salário médio</th>
                        <th>Cálculo da parcela</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Até R$ 2.041,39</td>
                        <td>Multiplica-se o salário médio por 0,8</td>
                    </tr>
                    <tr>
                        <td>De R$ 2.041,40 a R$ 3.402,65</td>
                        <td>O que exceder a R$ 2.041,39 multiplica-se por 0,5 e soma-se com R$ 1.633,10</td>
                    </tr>
                    <tr>
                        <td>Acima de R$ 3.402,65</td>
                        <td>O valor será invariável de R$ 2.313,74</td>
                    </tr>
                    <tr>
                        <td>Abaixo de R$ 1.412,00</td>
                        <td>O valor será ajustado para o salario mínimo de R$ 1.412,74</td>
                    </tr>
                </tbody>
            </table>
        `;
        new bootstrap.Modal(document.getElementById('exampleModal')).show();
    } catch (error) {
        console.error('Erro:', error);
        document.getElementById('modalBody').innerText = 'Erro ao calcular o benefício e as parcelas.';
        new bootstrap.Modal(document.getElementById('exampleModal')).show();
    }
}