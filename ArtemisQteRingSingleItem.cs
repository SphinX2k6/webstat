using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011C1 RID: 4545
[NullableContext(2)]
[Nullable(0)]
public class ArtemisQteRingSingleItem : UiPanelBase
{
	// Token: 0x060077AD RID: 30637 RVA: 0x001F5530 File Offset: 0x001F3730
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x060077AE RID: 30638 RVA: 0x001F55A0 File Offset: 0x001F37A0
	protected override UniTask OnBeforeStartAsync()
	{
		ArtemisQteRingSingleItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ArtemisQteRingSingleItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060077AF RID: 30639 RVA: 0x001F55E3 File Offset: 0x001F37E3
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x060077B0 RID: 30640 RVA: 0x001F5600 File Offset: 0x001F3800
	public void SetRotation(float angle)
	{
		FRotator frotator = Rotator.Create(0f, angle, 0f).ToUeRotator();
		ArtemisQteRingSingleAreaItem normalItem = this.NormalItem;
		if (normalItem != null)
		{
			normalItem.GetRootItem().SetUIRelativeRotation(frotator);
		}
		ArtemisQteRingSingleAreaItem missItem = this.MissItem;
		if (missItem != null)
		{
			missItem.GetRootItem().SetUIRelativeRotation(frotator);
		}
		ArtemisQteRingSingleAreaItem perfectItem = this.PerfectItem;
		if (perfectItem == null)
		{
			return;
		}
		perfectItem.GetRootItem().SetUIRelativeRotation(frotator);
	}

	// Token: 0x060077B1 RID: 30641 RVA: 0x001F566C File Offset: 0x001F386C
	public void InitItem()
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem != null)
		{
			FRotator frotator = Rotator.Create(0f, 0f, 0f).ToUeRotator();
			rootItem.SetUIRelativeRotation(frotator);
		}
		UUIItem rootItem2 = base.GetRootItem();
		if (rootItem2 != null)
		{
			rootItem2.SetUIItemScale(new FVector(1f, 1f, 1f));
		}
		UUIItem rootItem3 = base.GetRootItem();
		if (rootItem3 == null)
		{
			return;
		}
		rootItem3.SetAlpha(1f);
	}

	// Token: 0x060077B2 RID: 30642 RVA: 0x001F56E0 File Offset: 0x001F38E0
	public void SetType(EArtemisAreaType type)
	{
		this.SetActive(true);
		ArtemisQteRingSingleAreaItem normalItem = this.NormalItem;
		if (normalItem != null)
		{
			normalItem.SetHighLight(type == EArtemisAreaType.PerfectArea);
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(type == EArtemisAreaType.BlankArea);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetAlpha(1f);
		}
		UUIItem item3 = base.GetItem(2);
		if (item3 != null)
		{
			item3.SetAlpha(0f);
		}
		UUIItem item4 = base.GetItem(3);
		if (item4 == null)
		{
			return;
		}
		item4.SetAlpha(0f);
	}

	// Token: 0x060077B3 RID: 30643 RVA: 0x001F5764 File Offset: 0x001F3964
	public void SetFill(float amount)
	{
		ArtemisQteRingSingleAreaItem normalItem = this.NormalItem;
		if (normalItem != null)
		{
			normalItem.SetFillAmount(amount);
		}
		ArtemisQteRingSingleAreaItem missItem = this.MissItem;
		if (missItem != null)
		{
			missItem.SetFillAmount(amount);
		}
		ArtemisQteRingSingleAreaItem perfectItem = this.PerfectItem;
		if (perfectItem != null)
		{
			perfectItem.SetFillAmount(amount);
		}
		ArtemisQteRingSingleAreaItem normalItem2 = this.NormalItem;
		if (normalItem2 != null)
		{
			normalItem2.SetCustomMaterialScalarParameter(amount);
		}
		ArtemisQteRingSingleAreaItem missItem2 = this.MissItem;
		if (missItem2 != null)
		{
			missItem2.SetCustomMaterialScalarParameter(amount);
		}
		ArtemisQteRingSingleAreaItem perfectItem2 = this.PerfectItem;
		if (perfectItem2 == null)
		{
			return;
		}
		perfectItem2.SetCustomMaterialScalarParameter(amount);
	}

	// Token: 0x060077B4 RID: 30644 RVA: 0x001F57DC File Offset: 0x001F39DC
	public void SetAlpha(float alpha)
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetAlpha(alpha);
	}

	// Token: 0x060077B5 RID: 30645 RVA: 0x001F57F0 File Offset: 0x001F39F0
	[NullableContext(1)]
	public void PlayAnim(string sequenceName)
	{
		if (this.SequencePlayer.GetCurrentSequence() == sequenceName)
		{
			this.SequencePlayer.ReplaySequenceByKey(sequenceName);
			return;
		}
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x060077B6 RID: 30646 RVA: 0x001F5844 File Offset: 0x001F3A44
	[NullableContext(1)]
	public void PlayLevelSequenceByName(string sequenceName)
	{
		this.SequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x060077B7 RID: 30647 RVA: 0x001F5868 File Offset: 0x001F3A68
	[NullableContext(1)]
	public void StopPlayingSequence(string sequenceName)
	{
		if (this.SequencePlayer.GetCurrentSequence() == sequenceName)
		{
			this.SequencePlayer.StopPlayingSequence(false, true);
		}
	}

	// Token: 0x040039F2 RID: 14834
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040039F3 RID: 14835
	private ArtemisQteRingSingleAreaItem NormalItem;

	// Token: 0x040039F4 RID: 14836
	private ArtemisQteRingSingleAreaItem MissItem;

	// Token: 0x040039F5 RID: 14837
	private ArtemisQteRingSingleAreaItem PerfectItem;

	// Token: 0x02007518 RID: 29976
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040286D0 RID: 165584
		public const int PanelCircleTop = 0;

		// Token: 0x040286D1 RID: 165585
		public const int PanelAreaNormal = 1;

		// Token: 0x040286D2 RID: 165586
		public const int PanelAreaMiss = 2;

		// Token: 0x040286D3 RID: 165587
		public const int PanelAreaPerfect = 3;
	}
}
