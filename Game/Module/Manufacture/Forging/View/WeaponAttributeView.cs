using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059AC RID: 22956
	[NullableContext(1)]
	[Nullable(0)]
	public class WeaponAttributeView : UiPanelBase
	{
		// Token: 0x0603A1C4 RID: 238020 RVA: 0x00EB4F0C File Offset: 0x00EB310C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603A1C5 RID: 238021 RVA: 0x00EB5028 File Offset: 0x00EB3228
		protected override void OnStart()
		{
			if (this.FirstAttributeComponent == null)
			{
				this.FirstAttributeComponent = new AttributeItemInternal();
				this.FirstAttributeComponent.CreateThenShowByActor(base.GetItem(5).GetOwner());
			}
			if (this.SecondAttributeComponent == null)
			{
				this.SecondAttributeComponent = new AttributeItemInternal();
				this.SecondAttributeComponent.CreateThenShowByActor(base.GetItem(6).GetOwner());
			}
			this.StarView = new GenericLayout<WeaponAttributeView.StarItem, EStartState>(base.GetHorizontalLayout(3), new Func<WeaponAttributeView.StarItem>(this.InitStarItem), null, false, true);
			TArray<UUIItem> attachUIChildren = this.StarView.GetRootUiItem().GetAttachUIChildren();
			for (int i = 0; i < attachUIChildren.Num(); i++)
			{
				attachUIChildren.Get(i).SetUIActive(false);
			}
		}

		// Token: 0x0603A1C6 RID: 238022 RVA: 0x00EB50D9 File Offset: 0x00EB32D9
		private WeaponAttributeView.StarItem InitStarItem()
		{
			return new WeaponAttributeView.StarItem();
		}

		// Token: 0x0603A1C7 RID: 238023 RVA: 0x00EB50E0 File Offset: 0x00EB32E0
		private void RefreshSkillNameText()
		{
			WeaponReson? weaponResonanceConfig = ConfigBase<global::WeaponConfig>.Instance.GetWeaponResonanceConfig(this.WeaponConfig.Value.ResonId, 1);
			if (weaponResonanceConfig != null)
			{
				base.GetText(1).ShowTextNew(weaponResonanceConfig.Value.Name);
			}
		}

		// Token: 0x0603A1C8 RID: 238024 RVA: 0x00EB5130 File Offset: 0x00EB3330
		private void RefreshStar()
		{
			List<EStartState> data = new List<EStartState>(ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(this.WeaponConfig.Value.BreachId));
			this.StarView.RefreshByData(data, null, false);
		}

		// Token: 0x0603A1C9 RID: 238025 RVA: 0x00EB5170 File Offset: 0x00EB3370
		private void RefreshWeaponLevel()
		{
			int num = 1;
			int levelLimit = this.WeaponBreachConfig.Value.LevelLimit;
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "ForgingWeaponLevel", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				levelLimit
			}));
		}

		// Token: 0x0603A1CA RID: 238026 RVA: 0x00EB51C8 File Offset: 0x00EB33C8
		private void RefreshWeaponAttribute()
		{
			this.FirstAttributeComponent.UpdateParam(this.WeaponConfig.Value.FirstPropId.Value.Id, this.WeaponConfig.Value.FirstPropId.Value.IsRatio);
			float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(this.WeaponConfig.Value.FirstCurve, this.WeaponConfig.Value.FirstPropId.Value.Value, 1, 0);
			this.FirstAttributeComponent.SetCurrentValue(curveValue);
			this.SecondAttributeComponent.UpdateParam(this.WeaponConfig.Value.SecondPropId.Value.Id, this.WeaponConfig.Value.SecondPropId.Value.IsRatio);
			float curveValue2 = ModelBase<WeaponModel>.Instance.GetCurveValue(this.WeaponConfig.Value.SecondCurve, this.WeaponConfig.Value.SecondPropId.Value.Value, 1, 0);
			this.SecondAttributeComponent.SetCurrentValue(curveValue2);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "WeaponResonanceItemLevelText", new <>z__ReadOnlySingleElementList<object>("1"));
		}

		// Token: 0x0603A1CB RID: 238027 RVA: 0x00EB533C File Offset: 0x00EB353C
		public void RefreshTips(IWeaponForgingData data)
		{
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(data.ItemId);
			this.WeaponConfig = ConfigBase<global::WeaponConfig>.Instance.GetWeaponConfigByItemId(forgeFormulaById.Value.ItemId);
			this.WeaponBreachConfig = ConfigBase<global::WeaponConfig>.Instance.GetWeaponBreach(this.WeaponConfig.Value.BreachId, 1);
			this.RefreshSkillNameText();
			this.RefreshWeaponLevel();
			this.RefreshStar();
			this.RefreshWeaponAttribute();
		}

		// Token: 0x04020F5B RID: 135003
		private WeaponConf? WeaponConfig;

		// Token: 0x04020F5C RID: 135004
		private WeaponBreach? WeaponBreachConfig;

		// Token: 0x04020F5D RID: 135005
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<WeaponAttributeView.StarItem, EStartState> StarView;

		// Token: 0x04020F5E RID: 135006
		[Nullable(2)]
		private AttributeItemInternal FirstAttributeComponent;

		// Token: 0x04020F5F RID: 135007
		[Nullable(2)]
		private AttributeItemInternal SecondAttributeComponent;

		// Token: 0x04020F60 RID: 135008
		private const int CurrentLevel = 1;

		// Token: 0x04020F61 RID: 135009
		private const int CurrentBreach = 0;

		// Token: 0x0200B966 RID: 47462
		[Nullable(0)]
		public class StarItem : UiPanelBase, IGridProxy<EStartState>
		{
			// Token: 0x1700A98D RID: 43405
			// (get) Token: 0x0604D5C6 RID: 316870 RVA: 0x0155B00E File Offset: 0x0155920E
			// (set) Token: 0x0604D5C7 RID: 316871 RVA: 0x0155B016 File Offset: 0x01559216
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public IScrollViewDelegate<IGridProxy<EStartState>, EStartState> ScrollViewDelegate { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }

			// Token: 0x1700A98E RID: 43406
			// (get) Token: 0x0604D5C8 RID: 316872 RVA: 0x0155B01F File Offset: 0x0155921F
			// (set) Token: 0x0604D5C9 RID: 316873 RVA: 0x0155B027 File Offset: 0x01559227
			public int GridIndex { get; set; }

			// Token: 0x1700A98F RID: 43407
			// (get) Token: 0x0604D5CA RID: 316874 RVA: 0x0155B030 File Offset: 0x01559230
			// (set) Token: 0x0604D5CB RID: 316875 RVA: 0x0155B038 File Offset: 0x01559238
			public int DisplayIndex { get; set; }

			// Token: 0x0604D5CC RID: 316876 RVA: 0x0155B041 File Offset: 0x01559241
			public void Refresh(EStartState data, bool isSelected, int gridIndex)
			{
				if (data == EStartState.ON)
				{
					base.GetSprite(0).SetUIActive(true);
					base.GetSprite(1).SetUIActive(false);
					return;
				}
				base.GetSprite(0).SetUIActive(false);
				base.GetSprite(1).SetUIActive(true);
			}

			// Token: 0x0604D5CD RID: 316877 RVA: 0x0155B07E File Offset: 0x0155927E
			public void Clear()
			{
			}

			// Token: 0x0604D5CE RID: 316878 RVA: 0x0155B080 File Offset: 0x01559280
			public void OnSelected(bool fireEvent)
			{
			}

			// Token: 0x0604D5CF RID: 316879 RVA: 0x0155B082 File Offset: 0x01559282
			public void OnDeselected(bool fireEvent)
			{
			}

			// Token: 0x0604D5D0 RID: 316880 RVA: 0x0155B084 File Offset: 0x01559284
			public void CreateThenShowByActor(AActor actor)
			{
				base.CreateThenShowByActor(actor, null);
			}

			// Token: 0x0604D5D1 RID: 316881 RVA: 0x0155B090 File Offset: 0x01559290
			public UniTask CreateThenShowByActorAsync(AActor actor)
			{
				WeaponAttributeView.StarItem.<CreateThenShowByActorAsync>d__18 <CreateThenShowByActorAsync>d__;
				<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<CreateThenShowByActorAsync>d__.<>4__this = this;
				<CreateThenShowByActorAsync>d__.actor = actor;
				<CreateThenShowByActorAsync>d__.<>1__state = -1;
				<CreateThenShowByActorAsync>d__.<>t__builder.Start<WeaponAttributeView.StarItem.<CreateThenShowByActorAsync>d__18>(ref <CreateThenShowByActorAsync>d__);
				return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
			}

			// Token: 0x0604D5D2 RID: 316882 RVA: 0x0155B0DC File Offset: 0x015592DC
			public UniTask CreateByActorAsync(AActor actor)
			{
				WeaponAttributeView.StarItem.<CreateByActorAsync>d__19 <CreateByActorAsync>d__;
				<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<CreateByActorAsync>d__.<>4__this = this;
				<CreateByActorAsync>d__.actor = actor;
				<CreateByActorAsync>d__.<>1__state = -1;
				<CreateByActorAsync>d__.<>t__builder.Start<WeaponAttributeView.StarItem.<CreateByActorAsync>d__19>(ref <CreateByActorAsync>d__);
				return <CreateByActorAsync>d__.<>t__builder.Task;
			}

			// Token: 0x0604D5D3 RID: 316883 RVA: 0x0155B127 File Offset: 0x01559327
			public object GetKey(EStartState data, int gridIndex)
			{
				return data;
			}

			// Token: 0x0604D5D4 RID: 316884 RVA: 0x0155B130 File Offset: 0x01559330
			protected unsafe override void OnRegisterComponent()
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
				this.ComponentRegisterInfos = list;
				this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
			}

			// Token: 0x0604D5D5 RID: 316885 RVA: 0x0155B1C5 File Offset: 0x015593C5
			protected override void OnStart()
			{
				base.GetSprite(2).SetUIActive(false);
			}

			// Token: 0x0604D5D6 RID: 316886 RVA: 0x0155B1D4 File Offset: 0x015593D4
			public void SetState(bool isOn)
			{
			}

			// Token: 0x0200CF35 RID: 53045
			[NullableContext(0)]
			public class EStarItemComponents
			{
				// Token: 0x0403FD55 RID: 261461
				public const int ImgStarOn = 0;

				// Token: 0x0403FD56 RID: 261462
				public const int ImgStarOff = 1;

				// Token: 0x0403FD57 RID: 261463
				public const int ImgStarNext = 2;
			}
		}

		// Token: 0x0200B967 RID: 47463
		[NullableContext(0)]
		private class EWeaponAttributeComponents
		{
			// Token: 0x04039434 RID: 234548
			public const int TxtSkillGrade = 0;

			// Token: 0x04039435 RID: 234549
			public const int TxtSkillName = 1;

			// Token: 0x04039436 RID: 234550
			public const int TxtLevel = 2;

			// Token: 0x04039437 RID: 234551
			public const int PnlStar = 3;

			// Token: 0x04039438 RID: 234552
			public const int PnlAttr = 4;

			// Token: 0x04039439 RID: 234553
			public const int FirstAttributeItem = 5;

			// Token: 0x0403943A RID: 234554
			public const int SecondAttributeItem = 6;
		}
	}
}
