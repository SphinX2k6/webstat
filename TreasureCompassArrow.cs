using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FCD RID: 8141
[NullableContext(2)]
[Nullable(0)]
public class TreasureCompassArrow : UiPanelBase
{
	// Token: 0x0600F5BD RID: 62909 RVA: 0x00434904 File Offset: 0x00432B04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F5BE RID: 62910 RVA: 0x00434970 File Offset: 0x00432B70
	protected override void OnStart()
	{
		base.OnStart();
		this.IsVisible = false;
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(false);
		}
		this.ArrowItem = base.GetItem(0);
		UUIItem arrowItem = this.ArrowItem;
		if (arrowItem != null)
		{
			arrowItem.SetUIActive(true);
		}
		this.HighLightArrowItem = base.GetItem(1);
		UUIItem highLightArrowItem = this.HighLightArrowItem;
		if (highLightArrowItem != null)
		{
			highLightArrowItem.SetUIActive(false);
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F5BF RID: 62911 RVA: 0x004349EB File Offset: 0x00432BEB
	public void Clean()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600F5C0 RID: 62912 RVA: 0x00434A08 File Offset: 0x00432C08
	public void SetVisible(bool isVisible)
	{
		if (isVisible == this.IsVisible)
		{
			return;
		}
		this.IsVisible = isVisible;
		if (!isVisible)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			this.PlayCloseAsync().Forget();
			return;
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
		if (levelSequencePlayer3 == null)
		{
			return;
		}
		levelSequencePlayer3.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600F5C1 RID: 62913 RVA: 0x00434A90 File Offset: 0x00432C90
	private UniTask PlayCloseAsync()
	{
		TreasureCompassArrow.<PlayCloseAsync>d__10 <PlayCloseAsync>d__;
		<PlayCloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseAsync>d__.<>4__this = this;
		<PlayCloseAsync>d__.<>1__state = -1;
		<PlayCloseAsync>d__.<>t__builder.Start<TreasureCompassArrow.<PlayCloseAsync>d__10>(ref <PlayCloseAsync>d__);
		return <PlayCloseAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F5C2 RID: 62914 RVA: 0x00434AD3 File Offset: 0x00432CD3
	public void SetRotation(FRotator rotator)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIRelativeRotation(rotator);
	}

	// Token: 0x0600F5C3 RID: 62915 RVA: 0x00434AE7 File Offset: 0x00432CE7
	public void SetArrowScale(double scale)
	{
		this.ScaleVec.X = scale;
		this.ScaleVec.Y = scale;
		UUIItem arrowItem = this.ArrowItem;
		if (arrowItem == null)
		{
			return;
		}
		arrowItem.SetUIItemScale(this.ScaleVec.ToUeVectorOld());
	}

	// Token: 0x0600F5C4 RID: 62916 RVA: 0x00434B1C File Offset: 0x00432D1C
	public void SetHighLight(bool isHighLight)
	{
		if (isHighLight == this.IsHighLight)
		{
			return;
		}
		this.IsHighLight = isHighLight;
		UUIItem arrowItem = this.ArrowItem;
		if (arrowItem != null)
		{
			arrowItem.SetUIActive(!isHighLight);
		}
		UUIItem highLightArrowItem = this.HighLightArrowItem;
		if (highLightArrowItem != null)
		{
			highLightArrowItem.SetUIActive(isHighLight);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x040076CA RID: 30410
	private UUIItem ArrowItem;

	// Token: 0x040076CB RID: 30411
	private UUIItem HighLightArrowItem;

	// Token: 0x040076CC RID: 30412
	[Nullable(1)]
	private readonly Vector ScaleVec = Vector.Create();

	// Token: 0x040076CD RID: 30413
	private bool IsHighLight;

	// Token: 0x040076CE RID: 30414
	private bool IsVisible = true;

	// Token: 0x040076CF RID: 30415
	private LevelSequencePlayer LevelSequencePlayer;
}
