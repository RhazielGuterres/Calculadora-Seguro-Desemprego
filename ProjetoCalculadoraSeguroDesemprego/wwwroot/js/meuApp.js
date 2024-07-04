async function calcularSeguroDesemprego() {
    const ultimoSalario = parseFloat(document.getElementById('ultimoSalario').value);
    const penultimoSalario = parseFloat(document.getElementById('penultimoSalario').value);
    const antepenultimoSalario = parseFloat(document.getElementById('antepenultimoSalario').value);
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
        document.getElementById('modalBody').innerText = `A média dos salários é: R$ ${resultado.mediaSalarial.toFixed(2)}, Benefício: R$ ${resultado.parcela.toFixed(2)}`;
        new bootstrap.Modal(document.getElementById('exampleModal')).show();
    } catch (error) {
        console.error('Erro:', error);
        document.getElementById('modalBody').innerText = 'Erro ao calcular o benefício.';
        new bootstrap.Modal(document.getElementById('exampleModal')).show();
    }
}