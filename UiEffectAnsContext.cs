using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002C79 RID: 11385
[NullableContext(1)]
[Nullable(0)]
public class UiEffectAnsContext : UiAnsContextBase
{
	// Token: 0x17001DF4 RID: 7668
	// (get) Token: 0x06016D6B RID: 93547 RVA: 0x00656476 File Offset: 0x00654676
	public string EffectPath { get; }

	// Token: 0x17001DF5 RID: 7669
	// (get) Token: 0x06016D6C RID: 93548 RVA: 0x0065647E File Offset: 0x0065467E
	public USkeletalMeshComponent MeshComponent { get; }

	// Token: 0x17001DF6 RID: 7670
	// (get) Token: 0x06016D6D RID: 93549 RVA: 0x00656486 File Offset: 0x00654686
	public FName Socket { get; }

	// Token: 0x17001DF7 RID: 7671
	// (get) Token: 0x06016D6E RID: 93550 RVA: 0x0065648E File Offset: 0x0065468E
	public bool Attached { get; }

	// Token: 0x17001DF8 RID: 7672
	// (get) Token: 0x06016D6F RID: 93551 RVA: 0x00656496 File Offset: 0x00654696
	public bool AttachLocationOnly { get; }

	// Token: 0x17001DF9 RID: 7673
	// (get) Token: 0x06016D70 RID: 93552 RVA: 0x0065649E File Offset: 0x0065469E
	public FVectorDouble Location { get; }

	// Token: 0x17001DFA RID: 7674
	// (get) Token: 0x06016D71 RID: 93553 RVA: 0x006564A6 File Offset: 0x006546A6
	public FRotator Rotation { get; }

	// Token: 0x17001DFB RID: 7675
	// (get) Token: 0x06016D72 RID: 93554 RVA: 0x006564AE File Offset: 0x006546AE
	public FVectorDouble Scale { get; }

	// Token: 0x17001DFC RID: 7676
	// (get) Token: 0x06016D73 RID: 93555 RVA: 0x006564B6 File Offset: 0x006546B6
	public bool PlayOnEnd { get; }

	// Token: 0x17001DFD RID: 7677
	// (get) Token: 0x06016D74 RID: 93556 RVA: 0x006564BE File Offset: 0x006546BE
	public bool FasterStop { get; }

	// Token: 0x17001DFE RID: 7678
	// (get) Token: 0x06016D75 RID: 93557 RVA: 0x006564C6 File Offset: 0x006546C6
	public EffectContext EffectContext { get; }

	// Token: 0x17001DFF RID: 7679
	// (get) Token: 0x06016D76 RID: 93558 RVA: 0x006564CE File Offset: 0x006546CE
	public FName MultiInstanceKey { get; }

	// Token: 0x17001E00 RID: 7680
	// (get) Token: 0x06016D77 RID: 93559 RVA: 0x006564D6 File Offset: 0x006546D6
	public Action<USkeletalMeshComponent, int> OnEffectSpawn { get; }

	// Token: 0x06016D78 RID: 93560 RVA: 0x006564E0 File Offset: 0x006546E0
	public UiEffectAnsContext(string effectPath, USkeletalMeshComponent meshComponent, FName socket, bool attached, bool attachLocationOnly, FVectorDouble location, FRotator rotation, FVectorDouble scale, bool playOnEnd, bool fasterStop, EffectContext effectContext, FName effectInstanceName, Action<USkeletalMeshComponent, int> onEffectSpawn)
	{
		this.EffectPath = effectPath;
		this.MeshComponent = meshComponent;
		this.Socket = socket;
		this.Attached = attached;
		this.AttachLocationOnly = attachLocationOnly;
		this.Location = location;
		this.Rotation = rotation;
		this.Scale = scale;
		this.PlayOnEnd = playOnEnd;
		this.FasterStop = fasterStop;
		this.EffectContext = effectContext;
		this.MultiInstanceKey = effectInstanceName;
		this.OnEffectSpawn = onEffectSpawn;
	}

	// Token: 0x06016D79 RID: 93561 RVA: 0x00656558 File Offset: 0x00654758
	public override bool IsValid()
	{
		return this.EffectPath != null && this.Socket != null && this.MeshComponent != null;
	}

	// Token: 0x06016D7A RID: 93562 RVA: 0x00656580 File Offset: 0x00654780
	public override bool IsEqual(UiAnsContextBase inAnsContext)
	{
		UiEffectAnsContext uiEffectAnsContext = inAnsContext as UiEffectAnsContext;
		if (uiEffectAnsContext == null)
		{
			return false;
		}
		if (!this.IsValid() || !uiEffectAnsContext.IsValid())
		{
			return false;
		}
		FName a = (this.MultiInstanceKey == default(FName)) ? FNameUtil.NONE : this.MultiInstanceKey;
		FName b = (uiEffectAnsContext.MultiInstanceKey == default(FName)) ? FNameUtil.NONE : uiEffectAnsContext.MultiInstanceKey;
		return this.EffectPath == uiEffectAnsContext.EffectPath && this.Socket == uiEffectAnsContext.Socket && this.MeshComponent == uiEffectAnsContext.MeshComponent && a == b;
	}

	// Token: 0x0400B010 RID: 45072
	public int? Handle;
}
