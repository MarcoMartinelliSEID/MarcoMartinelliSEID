package Classi;

import java.text.DecimalFormat;

import prog.utili.Data;

public abstract class Referto implements Comparable<Referto> {
	
	public String ID;
	Data data;
	public Paziente paziente;
	
	private static int IDs = 0;
	
	public Referto(String data, Paziente paziente) {
		if(data.equalsIgnoreCase("oggi"))
			this.data = new Data();
		else
			this.data = new Data(data);
		this.paziente = paziente;
		this.ID = generaID();
	}

	private String generaID() {
		DecimalFormat df = new DecimalFormat("000000");
		return df.format(IDs++);
	}
	
	@Override
	public int compareTo(Referto o) {
		return this.data.compareTo(o.data);
	}
	
	public abstract int criticity();
	
	public abstract boolean validity();
	
	@Override
	public String toString() {
		return "Esame: " + this.ID + " - Data: " + this.data + " - " + this.paziente + " - Criticità: " + this.criticity();
	}

}
