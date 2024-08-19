package Classi;

import prog.utili.Data;

public class RefertoImmagine extends Referto {
	
	String nomeFile;
	String testo;
	String dottore;

	public RefertoImmagine(String data, Paziente paziente, String nomeFile, String testo, String dottore) {
		super(data, paziente);
		this.nomeFile = nomeFile;
		this.testo = testo;
		this.dottore = dottore;
	}
	
	@Override
	public int criticity() {
		if(this.testo.toLowerCase().contains("critico")) {
			return 9;
		}else
			return 0;
	}
	
	@Override
	public boolean validity() {
		Data oggi = new Data();
		if(this.criticity() == 9)
			return true;
		else if(this.data.quantoManca(oggi) <= 2)
			return true;
		else
			return false;
	}
	
	@Override
	public String toString() {
		return super.toString() + " - Nome File: " + this.nomeFile + " - Testo: " + this.testo + " - Dottore: " + this.dottore;
	}

}
