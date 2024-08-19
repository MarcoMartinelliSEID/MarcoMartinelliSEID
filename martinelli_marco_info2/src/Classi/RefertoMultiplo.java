package Classi;

import java.util.ArrayList;
import java.util.Collections;

import prog.utili.Data;

public class RefertoMultiplo extends Referto {
	
	public ArrayList<Esame> esami;

	public RefertoMultiplo(String data, Paziente paziente) {
		super(data, paziente);
		this.esami = new ArrayList<Esame>();
	}
	
	public void AddEsame(String nome, float valore) {
		Esame e = new Esame(nome, valore);
		this.esami.add(e);
	}

	@Override
	public int criticity() {
		if(this.esami.size() == 0)
			return 0;
		Collections.sort(this.esami);
		float max = this.esami.get(0).valore;
		float tot = 0;
		for(Esame e: this.esami) {
			tot += e.valore;
		}
		return (int)(max - (tot / this.esami.size())) * 10;
	}
	
	@Override
	public boolean validity() {
		Data oggi = new Data();
		if((this.criticity() / this.data.quantoManca(oggi)) > 2)
			return true;
		else
			return false;
	}
	
	@Override
	public String toString() {
		return super.toString();
	}

}
