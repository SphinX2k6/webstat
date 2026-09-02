using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020010C2 RID: 4290
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingTipsPopGrid : UiPanelBase
{
	// Token: 0x06006FA1 RID: 28577 RVA: 0x001D0CB4 File Offset: 0x001CEEB4
	public GolemHackingTipsPopGrid(GolemHackingTipsGirdInfo param)
	{
		this.Code = param.Code;
		this.Index = param.Index;
		this.NextIndex = param.NextIndex;
		this.Position.X = (double)param.PosX;
		this.Position.Y = (double)param.PosY;
		this.Position.Z = (double)param.PosZ;
		this.Size = param.Size;
	}

	// Token: 0x06006FA2 RID: 28578 RVA: 0x001D0D68 File Offset: 0x001CEF68
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FA3 RID: 28579 RVA: 0x001D0E58 File Offset: 0x001CF058
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(this.Code, true);
		}
		UUIItem rootItem = base.GetRootItem();
		FVector fvector = this.Position.ToUeVectorOld();
		rootItem.SetLGUISpaceAbsolutePosition(fvector);
		this.InitLine();
	}

	// Token: 0x06006FA4 RID: 28580 RVA: 0x001D0EAE File Offset: 0x001CF0AE
	protected override void OnBeforeDestroy()
	{
		this.ClearDelayTimer();
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x06006FA5 RID: 28581 RVA: 0x001D0ECE File Offset: 0x001CF0CE
	private void ClearDelayTimer()
	{
		if (this.DelayTimerHandle != null)
		{
			if (this.DelayTimerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.DelayTimerHandle);
			}
			this.DelayTimerHandle = null;
		}
	}

	// Token: 0x06006FA6 RID: 28582 RVA: 0x001D0F00 File Offset: 0x001CF100
	public void PlayAnim(int index)
	{
		this.ClearDelayTimer();
		int num = index * 250;
		if (num != 0)
		{
			this.DelayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 == null)
				{
					return;
				}
				sequencePlayer2.PlayOrReplaySequenceByName("Notice", false, null);
			}, (float)num, null, null, true, 1f);
			return;
		}
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayOrReplaySequenceByName("Notice", false, null);
	}

	// Token: 0x06006FA7 RID: 28583 RVA: 0x001D0F64 File Offset: 0x001CF164
	protected void InitLine()
	{
		if (this.NextIndex == -1)
		{
			return;
		}
		int num = this.Index % this.Size;
		int num2 = this.Index / this.Size;
		int num3 = this.NextIndex % this.Size;
		int num4 = this.NextIndex / this.Size - num2;
		int num5 = num3 - num;
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetUIActive(num4 > 0);
		}
		UUISprite sprite2 = base.GetSprite(0);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(num4 < 0);
		}
		UUISprite sprite3 = base.GetSprite(3);
		if (sprite3 != null)
		{
			sprite3.SetUIActive(num5 > 0);
		}
		UUISprite sprite4 = base.GetSprite(2);
		if (sprite4 != null)
		{
			sprite4.SetUIActive(num5 < 0);
		}
		if (num5 > 0)
		{
			int num6 = 135 * (num5 - 1) + 60;
			UUISprite sprite5 = base.GetSprite(3);
			if (sprite5 != null)
			{
				sprite5.SetWidth((float)num6);
			}
		}
		else if (num5 < 0)
		{
			int num7 = 135 * (-num5 - 1) + 60;
			UUISprite sprite6 = base.GetSprite(2);
			if (sprite6 != null)
			{
				sprite6.SetWidth((float)num7);
			}
		}
		if (num4 <= 0)
		{
			if (num4 < 0)
			{
				int num8 = 135 * (-num4 - 1) + 60;
				UUISprite sprite7 = base.GetSprite(0);
				if (sprite7 == null)
				{
					return;
				}
				sprite7.SetWidth((float)num8);
			}
			return;
		}
		int num9 = 135 * (num4 - 1) + 60;
		UUISprite sprite8 = base.GetSprite(1);
		if (sprite8 == null)
		{
			return;
		}
		sprite8.SetWidth((float)num9);
	}

	// Token: 0x040035A9 RID: 13737
	private const int PIXEL_OFFSET = 60;

	// Token: 0x040035AA RID: 13738
	private const int GRID_WIDTH = 135;

	// Token: 0x040035AB RID: 13739
	private const int INTERVAL_TIME = 250;

	// Token: 0x040035AC RID: 13740
	protected string Code = "";

	// Token: 0x040035AD RID: 13741
	protected int Index;

	// Token: 0x040035AE RID: 13742
	protected int NextIndex = -1;

	// Token: 0x040035AF RID: 13743
	protected Vector Position = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040035B0 RID: 13744
	protected int Size;

	// Token: 0x040035B1 RID: 13745
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040035B2 RID: 13746
	[Nullable(2)]
	private TimerHandle DelayTimerHandle;
}
