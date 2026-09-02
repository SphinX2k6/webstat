using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x0200231D RID: 8989
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class MotorcycleAlbumItemGrid : AutoAttachItem<IAlbumUiData>, IStaticVariableResetter
{
	// Token: 0x060111A2 RID: 70050 RVA: 0x004B2EA1 File Offset: 0x004B10A1
	static MotorcycleAlbumItemGrid()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleAlbumItemGrid.CreateStaticDefaultValue), new Action(MotorcycleAlbumItemGrid.ResetStaticDefaultValue));
	}

	// Token: 0x060111A3 RID: 70051 RVA: 0x004B2EC0 File Offset: 0x004B10C0
	public static void CreateStaticDefaultValue()
	{
		MotorcycleAlbumItemGrid.RotateCurve = null;
		MotorcycleAlbumItemGrid.ScaleCurve = null;
		MotorcycleAlbumItemGrid.AlphaCurve = null;
	}

	// Token: 0x060111A4 RID: 70052 RVA: 0x004B2ED4 File Offset: 0x004B10D4
	public static void ResetStaticDefaultValue()
	{
		MotorcycleAlbumItemGrid.RotateCurve = null;
		MotorcycleAlbumItemGrid.ScaleCurve = null;
		MotorcycleAlbumItemGrid.AlphaCurve = null;
	}

	// Token: 0x060111A5 RID: 70053 RVA: 0x004B2EE8 File Offset: 0x004B10E8
	[NullableContext(1)]
	public MotorcycleAlbumItemGrid(AActor actor) : base(actor)
	{
	}

	// Token: 0x060111A6 RID: 70054 RVA: 0x004B2F3C File Offset: 0x004B113C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendTogglePanelLike)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickPanelPlaying))
		};
	}

	// Token: 0x060111A7 RID: 70055 RVA: 0x004B30C8 File Offset: 0x004B12C8
	public IAlbumUiData GetAlbumData()
	{
		return this.AlbumData;
	}

	// Token: 0x060111A8 RID: 70056 RVA: 0x004B30D0 File Offset: 0x004B12D0
	private void OnExtendTogglePanelLike(EToggleState state)
	{
		if (this.AlbumData != null)
		{
			Action<MotorcycleAlbumItemGrid, int> onClickAlbumItem = this.OnClickAlbumItem;
			if (onClickAlbumItem == null)
			{
				return;
			}
			onClickAlbumItem(this, this.AlbumData.Id);
		}
	}

	// Token: 0x060111A9 RID: 70057 RVA: 0x004B30F6 File Offset: 0x004B12F6
	private void OnClickPanelPlaying()
	{
		if (this.AlbumData != null)
		{
			Action<MotorcycleAlbumItemGrid, int> onClickBtnPlay = this.OnClickBtnPlay;
			if (onClickBtnPlay == null)
			{
				return;
			}
			onClickBtnPlay(this, this.AlbumData.Id);
		}
	}

	// Token: 0x060111AA RID: 70058 RVA: 0x004B311C File Offset: 0x004B131C
	private int GetAlbumUnlockMusicNum()
	{
		if (this.AlbumData == null)
		{
			return 0;
		}
		if (this.AlbumData.Id == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			return ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().Count;
		}
		return this.AlbumData.UnlockMusicNum;
	}

	// Token: 0x060111AB RID: 70059 RVA: 0x004B315C File Offset: 0x004B135C
	private void RefreshState()
	{
		if (this.AlbumData == null)
		{
			return;
		}
		bool flag = this.GetAlbumUnlockMusicNum() > 0;
		bool flag2 = flag && ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum() == this.AlbumData.Id;
		bool isPause = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause();
		base.GetItem(5).SetUIActive(flag2 && !isPause);
		base.GetButton(4).RootUIComp.Get().SetUIActive(flag && !flag2 && this.SelectState);
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(flag2 && isPause);
		}
		bool flag3 = ModelBase<MotorcycleMusicPlayerModel>.Instance.IsTimeLimitAlbum(this.AlbumData.Id);
		UUIItem item2 = base.GetItem(12);
		if (item2 != null)
		{
			item2.SetUIActive(flag3);
		}
		if (flag3)
		{
			string albumTimeLimitRemainText = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetAlbumTimeLimitRemainText(this.AlbumData.Id);
			UUIText text = base.GetText(13);
			if (text == null)
			{
				return;
			}
			text.SetText(albumTimeLimitRemainText, true);
		}
	}

	// Token: 0x060111AC RID: 70060 RVA: 0x004B3254 File Offset: 0x004B1454
	protected override void OnRefreshItem(IAlbumUiData data)
	{
		if (data == null)
		{
			return;
		}
		this.AlbumData = data;
		PhonographAlbum config = data.Config;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(config.Title);
		}
		if (data.Id == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetText(ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().Count.ToString(), true);
			}
		}
		else
		{
			UUIText text3 = base.GetText(3);
			if (text3 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.UnlockMusicNum);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.AllMusicNum);
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
		bool uiactive = ModelBase<MotorcycleMusicPlayerModel>.Instance.CheckAlbumHasNewMusic(data.Id);
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		base.SetTextureByPath(config.Cover, base.GetTexture(8), null, null);
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(data.Id == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId());
		}
		base.GetExtendToggle(0).SetToggleStateForce(data.IsSelected.GetValueOrDefault() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshState();
	}

	// Token: 0x060111AD RID: 70061 RVA: 0x004B33A5 File Offset: 0x004B15A5
	public override void OnSelect()
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		if (this.AlbumData != null)
		{
			Action<int> onSelectAlbumItem = this.OnSelectAlbumItem;
			if (onSelectAlbumItem == null)
			{
				return;
			}
			onSelectAlbumItem(this.AlbumData.Id);
		}
	}

	// Token: 0x060111AE RID: 70062 RVA: 0x004B33DA File Offset: 0x004B15DA
	protected override void OnUnSelect()
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060111AF RID: 70063 RVA: 0x004B33EC File Offset: 0x004B15EC
	protected override void OnMoveItem()
	{
		float currentMovePercentage = base.GetCurrentMovePercentage();
		float num = Singleton<MathUtils>.Instance.RangeClamp(Math.Abs(this.RootItem.GetAnchorOffsetX()), 276f, 552f, 0f, 117f);
		if (currentMovePercentage > 0.5f)
		{
			num = -num;
		}
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetAnchorOffsetX(num);
		}
		float num2 = this.RootItem.GetAnchorOffsetX() + num;
		this.TmpRotate.Pitch = MotorcycleAlbumItemGrid.RotateCurve.GetFloatValue(num2);
		float floatValue = MotorcycleAlbumItemGrid.AlphaCurve.GetFloatValue(num2);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAlpha(floatValue);
		}
		float floatValue2 = MotorcycleAlbumItemGrid.ScaleCurve.GetFloatValue(num2);
		UUIItem item2 = base.GetItem(9);
		FRotator frotator = this.TmpRotate.ToUeRotator();
		item2.SetUIRelativeRotation(frotator);
		this.TmpVector.Set((double)floatValue2, (double)floatValue2, (double)floatValue2);
		base.GetItem(9).SetUIItemScale(this.TmpVector.ToUeVectorOld());
		if (num2 > 70f)
		{
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			UUIItem item4 = base.GetItem(6);
			if (item4 != null)
			{
				item4.SetAlpha(Singleton<MathUtils>.Instance.RangeClamp(num2, 70f, 170f, 0f, 1f));
			}
		}
		else
		{
			UUIItem item5 = base.GetItem(6);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
		}
		if (num2 < -70f)
		{
			UUIItem item6 = base.GetItem(7);
			if (item6 != null)
			{
				item6.SetUIActive(true);
			}
			UUIItem item7 = base.GetItem(7);
			if (item7 == null)
			{
				return;
			}
			item7.SetAlpha(Singleton<MathUtils>.Instance.RangeClamp(num2, -70f, -170f, 0f, 1f));
			return;
		}
		else
		{
			UUIItem item8 = base.GetItem(7);
			if (item8 == null)
			{
				return;
			}
			item8.SetUIActive(false);
			return;
		}
	}

	// Token: 0x04008680 RID: 34432
	public Action<int> OnSelectAlbumItem;

	// Token: 0x04008681 RID: 34433
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleAlbumItemGrid, int> OnClickAlbumItem;

	// Token: 0x04008682 RID: 34434
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleAlbumItemGrid, int> OnClickBtnPlay;

	// Token: 0x04008683 RID: 34435
	private IAlbumUiData AlbumData;

	// Token: 0x04008684 RID: 34436
	[Nullable(1)]
	protected global::Vector TmpVector = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04008685 RID: 34437
	[Nullable(1)]
	protected Rotator TmpRotate = Rotator.Create(0f, 0f, 0f);

	// Token: 0x04008686 RID: 34438
	public static UCurveFloat RotateCurve;

	// Token: 0x04008687 RID: 34439
	public static UCurveFloat ScaleCurve;

	// Token: 0x04008688 RID: 34440
	public static UCurveFloat AlphaCurve;

	// Token: 0x02008630 RID: 34352
	[NullableContext(0)]
	private class EAlbumComponents
	{
		// Token: 0x0402D617 RID: 185879
		public const int TogAlbum = 0;

		// Token: 0x0402D618 RID: 185880
		public const int PanelLike = 1;

		// Token: 0x0402D619 RID: 185881
		public const int TxtAlbumName = 2;

		// Token: 0x0402D61A RID: 185882
		public const int TxtDiscNum = 3;

		// Token: 0x0402D61B RID: 185883
		public const int BtnPlay = 4;

		// Token: 0x0402D61C RID: 185884
		public const int PanelPlaying = 5;

		// Token: 0x0402D61D RID: 185885
		public const int TexMaskL = 6;

		// Token: 0x0402D61E RID: 185886
		public const int TexMaskR = 7;

		// Token: 0x0402D61F RID: 185887
		public const int TexIcon = 8;

		// Token: 0x0402D620 RID: 185888
		public const int PanelOffset = 9;

		// Token: 0x0402D621 RID: 185889
		public const int ItemNew = 10;

		// Token: 0x0402D622 RID: 185890
		public const int PanelPause = 11;

		// Token: 0x0402D623 RID: 185891
		public const int PnlTimeLimit = 12;

		// Token: 0x0402D624 RID: 185892
		public const int UITextActor = 13;
	}
}
