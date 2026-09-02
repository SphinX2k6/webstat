using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02000BF1 RID: 3057
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CollisionUtils : Singleton<CollisionUtils>
{
	// Token: 0x06003296 RID: 12950 RVA: 0x00023729 File Offset: 0x00021929
	public FCollisionResponseContainer GetCollisionResponseContainer()
	{
		if (this.CollisionResponseContainerRef == null)
		{
			this.CollisionResponseContainerRef = new FCollisionResponseContainer();
		}
		UKismetSystemLibrary.SetAllChannels(ref this.CollisionResponseContainerRef, ECollisionResponse.ECR_Ignore);
		return this.CollisionResponseContainerRef;
	}

	// Token: 0x06003297 RID: 12951 RVA: 0x00023758 File Offset: 0x00021958
	public void SetCollisionResponseToPawn(UCapsuleComponent capsule, EPawnChannel pawnChannel, ECollisionResponse newResponse)
	{
		List<ECollisionChannel> list = new List<ECollisionChannel>();
		if (pawnChannel == EPawnChannel.All)
		{
			list.Add(KuroCollisionChannel.Pawn);
			list.Add(KuroCollisionChannel.PawnPlayer);
			list.Add(KuroCollisionChannel.PawnMonster);
		}
		else if (pawnChannel == EPawnChannel.Pawn)
		{
			list.Add(KuroCollisionChannel.Pawn);
		}
		else if (pawnChannel == EPawnChannel.PawnPlayer)
		{
			list.Add(KuroCollisionChannel.PawnPlayer);
		}
		else if (pawnChannel == EPawnChannel.PawnMonster)
		{
			list.Add(KuroCollisionChannel.PawnMonster);
		}
		foreach (ECollisionChannel channel in list)
		{
			capsule.SetCollisionResponseToChannel(channel, newResponse);
		}
	}

	// Token: 0x0400055A RID: 1370
	[Nullable(2)]
	private FCollisionResponseContainer CollisionResponseContainerRef;
}
