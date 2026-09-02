using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066EE RID: 26350
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightLevelDetailView : UiViewBase
	{
		// Token: 0x06041C5D RID: 269405 RVA: 0x010DF00E File Offset: 0x010DD20E
		public MotorFightLevelDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C5E RID: 269406 RVA: 0x010DF018 File Offset: 0x010DD218
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnChangeRoleBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnGotoBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C5F RID: 269407 RVA: 0x010DF364 File Offset: 0x010DD564
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightLevelDetailView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightLevelDetailView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C60 RID: 269408 RVA: 0x010DF3A8 File Offset: 0x010DD5A8
		protected override void OnHandleLoadScene()
		{
			Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorTakeRole);
			int trialRoleId = this.ViewModel.ActivityData.GetMotorFightRoleData(this.ViewModel.SelectedRoleId).TrialRoleId;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleId, true);
			Singleton<MotorcycleUiModelUtil>.Instance.LoadEquippedMotorAndRole(roleDataById.GetRoleId(), roleDataById.GetRoleSkinId(), null);
		}

		// Token: 0x06041C61 RID: 269409 RVA: 0x010DF408 File Offset: 0x010DD608
		protected override void OnBeforeShow()
		{
			Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), this.LevelData.LevelName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), this.LevelData.LevelDesc, Array.Empty<object>());
			bool flag = this.LevelData.Type == EMotorFightLevelType.Difficulty;
			bool flag2 = this.LevelData.Type == EMotorFightLevelType.Endless;
			UUIArtText artText = base.GetArtText(10);
			artText.SetUIActive(!flag2);
			artText.SetText(this.LevelData.Number);
			UUIItem uuiitem = artText;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(artText.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.SetTextureByPath(ConfigBase<MotorFightConfig>.Instance.GetMotorFightLevelType((int)this.LevelData.Type).Value.SelectLevelStateBg, base.GetTexture(4), null, null);
			base.SetTextureByPath(this.LevelData.LevelBg, base.GetTexture(5), null, null);
			UUITexture texture = base.GetTexture(6);
			UUIItem uuiitem2 = texture;
			bool bUseChangeColor2 = flag;
			fcolor = new FColor?(texture.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			UUISprite sprite = base.GetSprite(7);
			UUIItem uuiitem3 = sprite;
			bool bUseChangeColor3 = flag;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
			UUISprite sprite2 = base.GetSprite(11);
			UUIItem uuiitem4 = sprite2;
			bool bUseChangeColor4 = flag;
			fcolor = new FColor?(sprite2.changeColor);
			uuiitem4.SetChangeColor(bUseChangeColor4, fcolor);
			UUISprite sprite3 = base.GetSprite(12);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(flag2);
			}
			UUIText text = base.GetText(17);
			if (this.LevelData.BestScore != 0)
			{
				text.SetText(this.LevelData.BestScore.ToString(), true);
			}
			this.RefreshRoleInfo();
			UUIItem item = base.GetItem(20);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.ViewModel.ActivityData.IsRoleHasRedDot());
		}

		// Token: 0x06041C62 RID: 269410 RVA: 0x010DF5F0 File Offset: 0x010DD7F0
		private void RefreshRoleInfo()
		{
			int selectedRoleId = this.ViewModel.SelectedRoleId;
			MotorFightRoleData motorFightRoleData = this.ViewModel.ActivityData.GetMotorFightRoleData(selectedRoleId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), motorFightRoleData.RoleName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), motorFightRoleData.BuffName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), motorFightRoleData.BuffDesc, motorFightRoleData.BuffDescParams);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(motorFightRoleData.TrialRoleId, true);
			Singleton<MotorcycleUiModelUtil>.Instance.RefreshRoleInMotor(roleDataById.GetRoleId(), roleDataById.GetRoleSkinId(), motorFightRoleData.AnimPath);
		}

		// Token: 0x06041C63 RID: 269411 RVA: 0x010DF69F File Offset: 0x010DD89F
		protected override void OnHandleReleaseScene()
		{
			Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
		}

		// Token: 0x06041C64 RID: 269412 RVA: 0x010DF6AB File Offset: 0x010DD8AB
		private CommonItemSmallItemGrid CreateItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => this.LevelData.IsFinished)
			};
		}

		// Token: 0x06041C65 RID: 269413 RVA: 0x010DF6C4 File Offset: 0x010DD8C4
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041C66 RID: 269414 RVA: 0x010DF6CD File Offset: 0x010DD8CD
		private void OnChangeRoleBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightRoleSelectView, this.ViewModel, null);
		}

		// Token: 0x06041C67 RID: 269415 RVA: 0x010DF6E5 File Offset: 0x010DD8E5
		private void OnGotoBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.EnterMotorFightDungeonDirectly(this.LevelData.Id, this.ViewModel.SelectedRoleId, false);
		}

		// Token: 0x04024B1B RID: 150299
		private MotorFightLevelData LevelData;

		// Token: 0x04024B1C RID: 150300
		private MotorFightLevelDetailViewModel ViewModel;

		// Token: 0x04024B1D RID: 150301
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B1E RID: 150302
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0200C72E RID: 50990
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D512 RID: 251154
			public const int ItemCaption = 0;

			// Token: 0x0403D513 RID: 251155
			public const int TextRoleName = 1;

			// Token: 0x0403D514 RID: 251156
			public const int TextBuffDesc = 2;

			// Token: 0x0403D515 RID: 251157
			public const int BtnChangeRole = 3;

			// Token: 0x0403D516 RID: 251158
			public const int TextureBg = 4;

			// Token: 0x0403D517 RID: 251159
			public const int TextureInfoBg = 5;

			// Token: 0x0403D518 RID: 251160
			public const int TextureTitleBg = 6;

			// Token: 0x0403D519 RID: 251161
			public const int SpriteTitleLight = 7;

			// Token: 0x0403D51A RID: 251162
			public const int TextLevelName = 8;

			// Token: 0x0403D51B RID: 251163
			public const int ItemNumberPanel = 9;

			// Token: 0x0403D51C RID: 251164
			public const int ArtNumber = 10;

			// Token: 0x0403D51D RID: 251165
			public const int SpriteNumberBg = 11;

			// Token: 0x0403D51E RID: 251166
			public const int SpriteEndlessIcon = 12;

			// Token: 0x0403D51F RID: 251167
			public const int ItemRewardPanel = 13;

			// Token: 0x0403D520 RID: 251168
			public const int TextLevelDesc = 14;

			// Token: 0x0403D521 RID: 251169
			public const int LayoutReward = 15;

			// Token: 0x0403D522 RID: 251170
			public const int ItemReward = 16;

			// Token: 0x0403D523 RID: 251171
			public const int TextScore = 17;

			// Token: 0x0403D524 RID: 251172
			public const int BtnGoto = 18;

			// Token: 0x0403D525 RID: 251173
			public const int TextBuffName = 19;

			// Token: 0x0403D526 RID: 251174
			public const int ItemChangeBtnRedDot = 20;
		}
	}
}
