export default {
    toStringPtBr: function(data) {
      data = new Date(data);
      var dia = String(data.getDate());
      var mes = String(data.getMonth() + 1);
      var ano = data.getFullYear();
      dia = dia.length === 2 ? dia : "0" + dia;
      mes = mes.length === 2 ? mes : "0" + mes;
  
      return ano + "/" + mes + "/" + dia;
    },
  
    converterData: function(valor) {
      if (valor instanceof Date) {
        return valor;
      } else if (typeof valor === "string") {
        if (valor.indexOf("/") !== -1) {
          let dia = valor.split("/")[0];
          let mes = Number(valor.split("/")[1] - 1);
          let ano = valor.split("/")[2];
  
          return new Date(ano, mes, dia);
        } else if (valor.indexOf("-") !== -1) {
          let dia = valor.split("-")[2].substring(0, 2);
          let mes = Number(valor.split("-")[1] - 1);
          let ano = valor.split("-")[0];
  
          return new Date(ano, mes, dia);
        }
      }
      return null;
    },
  
    addDays(date, days) {
      let result = new Date(date);
      result.setDate(result.getDate() + days);
  
      return result;
    },
  
    obterMaiorData(data1, data2) {
      const primeiraData = new Date(
        data1.getFullYear(),
        data1.getMonth(),
        data1.getDate()
      );
      const segundaData = new Date(
        data2.getFullYear(),
        data2.getMonth(),
        data2.getDate()
      );
  
      if (primeiraData > segundaData) return 1;
      else if (segundaData > primeiraData) return 2;
      else return 0;
    },
  
    obterHorarioAtual() {
      const horaAtual = new Date().getHours();
      const minutoAtual = new Date().getMinutes();
      const horarioAtual =
        (horaAtual >= 10 ? horaAtual : "0" + horaAtual) +
        ":" +
        (minutoAtual >= 10 ? minutoAtual : "0" + minutoAtual);
      return horarioAtual;
    },
  
    obterDataParaDatepicker(dataSrc) {
      if (dataSrc) {
        const data = new Date(dataSrc);
  
        const y = data.getFullYear();
        const m = data.getMonth();
        const d = data.getDate();
  
        const dataFinal = new Date(y, m, d);
  
        return dataFinal;
      }
  
      return null;
    },
  };
  