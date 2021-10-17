<template>
	<input
		ref="input"
		autocomplete="off"
		class="pikaday-vue-datepicker"
		maxlength="10"
		type="text"
		inputmode="numeric"
		v-bind:value="value"
		v-bind:id="nome"
		v-on:blur="validarData($event)"
		v-on:keypress="somenteCaracteresPermitidos($event)"
		v-on:keydown="mascara($event)"
	/>
</template>
<script>

import Pikaday from 'pikaday'

export default {
	props: {
		value: {},
		nome: {
			type: String,
			required: true
		},
		botao: {
			type: String,
			required: false,
			default: ''
		}
	},
	data: function () {
		return {
			picker: {}
		};
	},
	mounted: function () {
		var self = this;
		self.init();
		document.getElementById(self.nome).removeEventListener('change', self.picker._onInputChange);
	},
	watch: {
		value: function (data) {
			var self = this;
			if (self.picker.getDate() == null) {
				self.setData(data);
				return;
			}

			if (data != self.formataDataValida(self.picker.getDate(), 'DD/MM/YYYY')) {
				self.setData(data);
			}
		}
	},
	methods: {
		init: function () {
			var self = this;
			self.picker = new Pikaday({
				field: document.getElementById(self.nome),
				ariaLabel: 'Custom label',
				format: 'DD/MM/YYYY',
				bound: true,
				trigger: document.getElementById(self.botao),
				yearRange: [1950, 2020],
				showDaysInNextAndPreviousMonths: true,
				enableSelectionDaysInNextAndPreviousMonths: true,
				position: 'bottom right',
				blurFieldOnSelect: false,
				reposition: false,
				i18n: {
					previousMonth: 'Mês anterior',
					nextMonth: 'Próximo Mês',
					months: ['Janeiro', 'Fevereiro', 'Mar\u00e7o', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
					weekdays: ['Domingo', 'Segunda-feira', 'Ter\u00e7a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'S\u00e1bado'],
					weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab']
				},
				onSelect: function (data) {
					self.atualizaInput(new Date(data));
				}
			});
		},

		atualizaInput: function (valor) {
			var self = this;
			var valorFormatado = self.formataDataValida(valor, 'DD/MM/YYYY');
			self.$emit('input', valorFormatado);
			this.$refs.input.value = valorFormatado;
		},

		mascara: function (evento) {
			var self = this;
			var valorCampo = evento.target.value;

			if (valorCampo.length == 2 && evento.keyCode >= 48 && evento.keyCode <= 57) {
				self.$refs.input.value = valorCampo + '/';
			}
			if (valorCampo.length == 5 && evento.keyCode >= 48 && evento.keyCode <= 57) {
				self.$refs.input.value = valorCampo + '/';
			}

			if (valorCampo.length == 2 && evento.keyCode >= 96 && evento.keyCode <= 105) {
				self.$refs.input.value = valorCampo + '/';
			}
			if (valorCampo.length == 5 && evento.keyCode >= 96 && evento.keyCode <= 105) {
				self.$refs.input.value = valorCampo + '/';
			}

			if (self.$refs.input.value.length == 9) {
				if (self.ehDataValida(valorCampo + String(evento.key))) {
					self.picker.setDate(self.formataDataValida(valorCampo + String(evento.key), 'MM/DD/YYYY'));
					self.picker.hide();
				}
			}
		},

		somenteCaracteresPermitidos: function (evento) {
			evento = evento ? evento : window.event;
			var charCode = evento.which ? evento.which : evento.keyCode;

			if (charCode > 31 && (charCode < 47 || charCode > 57)) {
				evento.preventDefault();
			} else {
				return true;
			}
		},

		validarData: function (evento) {
			var self = this;
			var data = evento.target.value;
			if (data && !self.ehDataValida(data)) {
				self.$refs.input.value = '';
				self.$emit('input', '');
				self.$emit('datainvalida');
			} else if (data) {
				self.atualizaInput(data);
			} else {
				self.$refs.input.value = '';
				self.$emit('input', '');
			}
		},

		formataDataValida: function (data, format) {
			var dia, mes, ano;
			if (!(data instanceof Date)) {
				dia = data.split('/')[0];
				mes = data.split('/')[1];
				ano = data.split('/')[2];
			} else {
				dia = data.getDate();
				dia = String(dia).length == 1 ? '0' + String(dia) : dia;

				mes = data.getMonth() + 1;
				mes = String(mes).length == 1 ? '0' + String(mes) : mes;

				ano = data.getFullYear();
			}

			format = format.replace('DD', dia).replace('MM', mes).replace('YYYY', ano);

			return format;
		},

		ehDataValida: function (data) {
			if (data instanceof Date) {
				var timestamp = Date.parse(data);
				if (!isNaN(timestamp)) {
					return true;
				}
			} else {
				if (data.split('/').length == 3) {
					var dia = data.split('/')[0];
					var mes = data.split('/')[1];
					mes = Number(mes) - 1;

					var ano = data.split('/')[2];

					if (String(ano).length < 4) {
						return false;
					}

					data = new Date(ano, mes, dia);

					if (data.getFullYear() == ano && data.getMonth() == mes && data.getDate() == dia) {
						return true;
					}
				}

				return false;
			}
		},

		setData: function (data) {
			if (typeof data === 'string') {
				this.picker.setDate(this.formataDataValida(data, 'MM/DD/YYYY'));
			} else {
				this.picker.setDate(data);
			}
		}
	}
};
</script>
<style>
@charset "UTF-8";

/*!
 * Pikaday
 * Copyright © 2014 David Bushell | BSD & MIT license | http://dbushell.com/
 */

.pika-single {
	z-index: 9999;
	display: block;
	position: relative;
	color: #333;
	background: #fff;
	border: 1px solid #ccc;
	border-bottom-color: #bbb;
	color: rgb(51, 51, 51);
}

/*
clear child float (pika-lendar), using the famous micro clearfix hack
http://nicolasgallagher.com/micro-clearfix-hack/
*/
.pika-single:before,
.pika-single:after {
	content: ' ';
	display: table;
}

.pika-single:after {
	clear: both;
}

.pika-single {
	*zoom: 1;
}

.pika-single.is-hidden {
	display: none;
}

.pika-single.is-bound {
	position: absolute;
	box-shadow: 0 5px 15px -5px rgba(0, 0, 0, 0.5);
}

.pika-lendar {
	float: right;
	width: 240px;
	margin: 8px;
	font-family: NeoSansPro-Regular, Verdana, sans-serif;
}

.pika-title {
	position: relative;
	text-align: center;
}

.pika-label {
	display: inline-block;
	*display: inline;
	position: relative;
	z-index: 9999;
	overflow: hidden;
	margin: 0;
	padding: 5px 3px;
	/*font-size: 14px;*/
	line-height: 20px;
	background-color: #fff;
	/*novo*/
	font-size: 18px;
	font-weight: bold;
}

.pika-title select {
	cursor: pointer;
	position: absolute;
	z-index: 9998;
	margin: 0;
	left: 0;
	top: 5px;
	filter: alpha(opacity=0);
	opacity: 0;
}

.pika-prev,
.pika-next {
	display: block;
	cursor: pointer;
	position: relative;
	outline: none;
	border: 0;
	padding: 0;
	width: 20px;
	height: 30px;
	/* hide text using text-indent trick, using width value (it's enough) */
	text-indent: 20px;
	white-space: nowrap;
	overflow: hidden;
	background-color: transparent;
	background-position: center center;
	background-repeat: no-repeat;
	background-size: 75% 75%;
	opacity: 0.5;
	*position: absolute;
	*top: 0;
}

.pika-prev:hover,
.pika-next:hover {
	opacity: 1;
}

.pika-prev,
.is-rtl .pika-next {
	float: left;
	background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAeCAYAAAAsEj5rAAAAUklEQVR42u3VMQoAIBADQf8Pgj+OD9hG2CtONJB2ymQkKe0HbwAP0xucDiQWARITIDEBEnMgMQ8S8+AqBIl6kKgHiXqQqAeJepBo/z38J/U0uAHlaBkBl9I4GwAAAABJRU5ErkJggg==');
	*left: 0;
}

.pika-next,
.is-rtl .pika-prev {
	float: right;
	background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAeCAYAAAAsEj5rAAAAU0lEQVR42u3VOwoAMAgE0dwfAnNjU26bYkBCFGwfiL9VVWoO+BJ4Gf3gtsEKKoFBNTCoCAYVwaAiGNQGMUHMkjGbgjk2mIONuXo0nC8XnCf1JXgArVIZAQh5TKYAAAAASUVORK5CYII=');
	*right: 0;
}

.pika-prev.is-disabled,
.pika-next.is-disabled {
	cursor: default;
	opacity: 0.2;
}

.pika-select {
	display: inline-block;
	*display: inline;
}

.pika-table {
	width: 100%;
	border-collapse: collapse;
	border-spacing: 0;
	border: 0;
}

.pika-table th,
.pika-table td {
	width: 14.285714285714286%;
	padding: 0;
}

.pika-table thead th {
	font-weight: bold;
	color: black;
	font-size: 15px;
}

.pika-table th {
	color: #999;
	font-size: 12px;
	line-height: 25px;
	font-weight: bold;
	text-align: center;
}

.pika-button {
	cursor: pointer;
	display: block;
	box-sizing: border-box;
	-moz-box-sizing: border-box;
	outline: none;
	border: 0;
	margin: 0;
	width: 100%;
	padding: 5px;
	color: #666;
	font-size: 15px;
	line-height: 15px;
	text-align: right;
	background: white;
	font-family: NeoSansPro-Regular, Verdana, sans-serif;
}

.pika-week {
	font-size: 11px;
	color: #999;
}

.is-today .pika-button {
	color: #ff8000;
	font-weight: bold;
}

.is-selected .pika-button,
.has-event .pika-button {
	color: #fff;
	font-weight: bold;
	background: #ff8000;
	box-shadow: inset 0 1px 3px #178fe5;
	border-radius: 3px;
}

.has-event .pika-button {
	background: #005da9;
	box-shadow: inset 0 1px 3px #0076c9;
}

.is-disabled .pika-button,
.is-inrange .pika-button {
	background: #d5e9f7;
}

.is-startrange .pika-button {
	color: #fff;
	background: #6cb31d;
	box-shadow: none;
	border-radius: 3px;
}

.is-endrange .pika-button {
	color: #fff;
	background: #ff8000;
	box-shadow: none;
	border-radius: 3px;
}

.is-disabled .pika-button {
	pointer-events: none;
	cursor: default;
	color: #999;
	opacity: 0.3;
}

.is-outside-current-month .pika-button {
	color: #999;
	opacity: 0.3;
}

.is-selection-disabled {
	pointer-events: none;
	cursor: default;
}

.pika-button:hover,
.pika-row.pick-whole-week:hover .pika-button {
	color: #fff;
	background: #ff8000;
	box-shadow: none;
	border-radius: 3px;
}

/* styling for abbr */
.pika-table abbr {
	border-bottom: none;
	cursor: help;
	text-decoration: none;
}

.pikaday-vue-datepicker::-ms-clear {
	display: none;
}

.pika-calendar-icon-mcx img {
	height: 30px;
	width: 30px;
	cursor: pointer;
}

/* styling for mcx-datepicker-periodo */
.mcx-datepicker-periodo-container-lista-tipos-periodo {
	height: auto;
	width: auto;
	background-color: #fff;
	box-shadow: 0 0.8rem 1.5rem rgba(0, 0, 0, 0.5) !important;
	z-index: 9999 !important;
}

.mcx-datepicker-periodo-item-lista-tipos-periodo {
	padding-left: 5px;
	padding-right: 10px;
}

.mcx-datepicker-periodo-item-lista-tipos-periodo:hover {
	cursor: pointer;
	background-color: #5b2e90;
	color: white;
}

.mcx-datepicker-periodo-span-tipo-filtro {
	cursor: pointer;
	position: relative;
	height: 20px;
	width: 30px;
	display: inline-block;
	border-radius: 3px;
}

.mcx-datepicker-periodo-span-tipo-filtro img {
	height: 25px;
	position: absolute;
}

.mcx-datepicker-periodo-span-separador-inputs {
	display: inline-block;
	width: 20px;
	text-align: center;
	padding-top: 5px;
}

.mcx-datepicker-periodo-input {
	float: left;
	width: auto !important;
}
</style>
