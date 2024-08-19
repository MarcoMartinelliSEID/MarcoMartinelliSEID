package Classi;

import prog.utili.Data;

public class RefertoSingolo extends Referto {
	
	String nome;
	RisultatoReferto risultato;

	public RefertoSingolo(String data, Paziente paziente, String nome, RisultatoReferto risultato) {
		super(data, paziente);
		this.nome = nome;
		this.risultato = risultato;
	}

	@Override
	public int criticity() {
		switch (this.risultato) {
		case POSITIVO:
			return 10;
		case NEGATIVO:
			return 0;
		case DUBBIO:
			return 5;
		}
		return 0;
	}

	@Override
	public boolean validity() {
		Data oggi = new Data();
		if(this.data.quantoManca(oggi) <= 5)
			return true;
		else return false;
	}
	
	@Override
	public String toString() {
		return super.toString() + " - Nome Referto: " + this.nome + " - Risultato: " + this.risultato.toString();
	}

}
