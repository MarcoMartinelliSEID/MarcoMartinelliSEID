package Classi;

public class Esame implements Comparable<Esame>{
	
	String nome;
	float valore;
	
	public Esame (String nome, float valore) {
		this.nome = nome;
		this.valore = valore;
	}

	@Override
	public int compareTo(Esame o) {
		return Float.valueOf(this.valore).compareTo(o.valore);
	}

}
