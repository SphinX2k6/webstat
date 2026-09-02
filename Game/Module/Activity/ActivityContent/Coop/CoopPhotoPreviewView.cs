using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006998 RID: 27032
	[NullableContext(2)]
	[Nullable(0)]
	public class CoopPhotoPreviewView : UiViewBase
	{
		// Token: 0x1700A1E7 RID: 41447
		// (get) Token: 0x060430DA RID: 274650 RVA: 0x01138277 File Offset: 0x01136477
		public new CoopPhotoPreviewViewParams OpenParam
		{
			get
			{
				return this.OpenParam as CoopPhotoPreviewViewParams;
			}
		}

		// Token: 0x060430DB RID: 274651 RVA: 0x01138284 File Offset: 0x01136484
		[NullableContext(1)]
		public CoopPhotoPreviewView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060430DC RID: 274652 RVA: 0x01138290 File Offset: 0x01136490
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x060430DD RID: 274653 RVA: 0x011382EC File Offset: 0x011364EC
		protected override void OnBeforeCreate()
		{
			this.ActData = this.OpenParam.ActivityData;
			this.RoleId = this.OpenParam.RoleId;
			CoopActivityData actData = this.ActData;
			this.TimeStamp = ((actData != null) ? actData.GetRoleMaxLevelTimeStamp(this.RoleId) : 0L);
		}

		// Token: 0x060430DE RID: 274654 RVA: 0x0113833C File Offset: 0x0113653C
		protected override UniTask OnBeforeStartAsync()
		{
			CoopPhotoPreviewView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CoopPhotoPreviewView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060430DF RID: 274655 RVA: 0x01138380 File Offset: 0x01136580
		protected override void OnBeforeShow()
		{
			CoopRole? coopRoleConfigByRoleId = ConfigBase<CoopConfig>.Instance.GetCoopRoleConfigByRoleId(this.RoleId);
			string text = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? (((coopRoleConfigByRoleId != null) ? coopRoleConfigByRoleId.GetValueOrDefault().BigPhotoPathM : null) ?? "") : (((coopRoleConfigByRoleId != null) ? coopRoleConfigByRoleId.GetValueOrDefault().BigPhotoPathF : null) ?? "");
			if (!string.IsNullOrEmpty(text))
			{
				base.SetTextureByPath(text, base.GetTexture(1), null, null);
			}
			DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp((double)this.TimeStamp);
			string birthLocalText = ConfigBase<PersonalConfig>.Instance.GetBirthLocalText(dataFromTimeStamp.Month, EBirthDateType.MONTH);
			string birthLocalText2 = ConfigBase<PersonalConfig>.Instance.GetBirthLocalText(dataFromTimeStamp.Day, EBirthDateType.DAY);
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("BirthDay");
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(textContentIdById, new string[]
			{
				birthLocalText,
				birthLocalText2
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Coop_Role_Photo", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Year,
				multiText
			}));
		}

		// Token: 0x060430E0 RID: 274656 RVA: 0x011384B5 File Offset: 0x011366B5
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040255A6 RID: 152998
		private CoopActivityData ActData;

		// Token: 0x040255A7 RID: 152999
		private int RoleId;

		// Token: 0x040255A8 RID: 153000
		private long TimeStamp;

		// Token: 0x040255A9 RID: 153001
		private PopupCaptionItem CaptionItem;
	}
}
