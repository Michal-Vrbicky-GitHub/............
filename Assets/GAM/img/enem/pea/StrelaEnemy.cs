using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrelaEnemy : Strela
{
	protected override void OnTriggerEnter2D(Collider2D HITcoLlidER)
	{	LifeController lifeController = HITcoLlidER.GetComponent<LifeController>();
		Aktor akControll = HITcoLlidER.GetComponent<Aktor>();
		if (lifeController != null)
		{	Pytliik pytliikComponent = HITcoLlidER.GetComponent<Pytliik>();
			PeaShooter peaComponent = HITcoLlidER.GetComponentInChildren<PeaShooter>();
			BuffTotem kufComponent = HITcoLlidER.GetComponentInChildren<BuffTotem>();
			AAAAAAAA aComponent = HITcoLlidER.GetComponentInChildren<AAAAAAAA>();
			Tank tonkComponent = HITcoLlidER.GetComponentInChildren<Tank>();
			AA aaComponent = HITcoLlidER.GetComponentInChildren<AA>();
			if (peaComponent != null  ||  pytliikComponent != null  ||  kufComponent != null  ||  aComponent != null  ||  tonkComponent != null  ||  aaComponent != null)
				return;
			lifeController.DMG(dmg);

			// Naklonuj znič a projektil bum
			NaklonujBum();
			Destroy(gameObject);
		}else if (akControll != null){
			akControll.dmg(dmg);//Demagogie (z řeckého δημος, démos = „lid“ + αγωγος agógos = „vůdce“) je v moderní době působivé a klamné řečnické vystupování, využívané k získání vlivu, politické podpory a moci, zejména mezi lidmi neschopnými kriticky myslet. Místo věcného zdůvodňování působí hlavně na předsudky a emoce posluchačů, k čemuž slouží polopravdy, překroucené argumenty, logické klamy, falešné sliby, vyvolávání strachu a podobně.
			NaklonujBum();
			Destroy(gameObject);
		}
	}
}
