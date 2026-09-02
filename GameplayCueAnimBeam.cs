using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F98 RID: 12184
[NullableContext(2)]
[Nullable(0)]
public class GameplayCueAnimBeam : GameplayCueBase
{
	// Token: 0x06018D8D RID: 101773 RVA: 0x007096B0 File Offset: 0x007078B0
	protected override void OnInit()
	{
		string[] array = this.CueConfig.Socket.Split('#', StringSplitOptions.None);
		this.Sockets = new List<FName>(array.Length);
		foreach (string key in array)
		{
			this.Sockets.Add(FNameUtil.GetDynamicFName(key).Value);
		}
	}

	// Token: 0x06018D8E RID: 101774 RVA: 0x00709710 File Offset: 0x00707910
	protected override void OnTick(float delta)
	{
		FVectorDouble[] points = (from socket in this.Sockets
		select this.ActorInternal.Mesh.D_GetSocketLocation(socket)).ToArray<FVectorDouble>();
		this.BeamItem.Tick(points, delta);
	}

	// Token: 0x06018D8F RID: 101775 RVA: 0x00709747 File Offset: 0x00707947
	protected override void OnCreate()
	{
		this.BeamItem = GameplayCueBeamCommonItem.Spawn(this.ActorInternal, this.CueConfig.Path, null);
	}

	// Token: 0x06018D90 RID: 101776 RVA: 0x00709766 File Offset: 0x00707966
	protected override void OnDestroy()
	{
		this.BeamItem.Destroy();
	}

	// Token: 0x06018D91 RID: 101777 RVA: 0x00709773 File Offset: 0x00707973
	public override void OnEnable()
	{
		this.BeamItem.GetOwner().SetActorHiddenInGame(false);
	}

	// Token: 0x06018D92 RID: 101778 RVA: 0x00709786 File Offset: 0x00707986
	public override void OnDisable()
	{
		this.BeamItem.GetOwner().SetActorHiddenInGame(true);
	}

	// Token: 0x0400C20D RID: 49677
	private GameplayCueBeamCommonItem BeamItem;

	// Token: 0x0400C20E RID: 49678
	private List<FName> Sockets;
}
