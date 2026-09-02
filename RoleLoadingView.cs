using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020DF RID: 8415
public class RoleLoadingView : LoadingViewBase
{
	// Token: 0x06010153 RID: 65875 RVA: 0x00469F75 File Offset: 0x00468175
	[NullableContext(1)]
	public RoleLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010154 RID: 65876 RVA: 0x00469F80 File Offset: 0x00468180
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010155 RID: 65877 RVA: 0x0046A04C File Offset: 0x0046824C
	protected override void OnStart()
	{
		base.OnStart();
		this.InitContent();
	}

	// Token: 0x06010156 RID: 65878 RVA: 0x0046A05C File Offset: 0x0046825C
	private void InitContent()
	{
		CharacterDisplayStyle? roleLoading = ModelBase<LoadingModel>.Instance.RoleLoading;
		if (roleLoading == null)
		{
			return;
		}
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText text = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CharacterDisplayStyle_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleLoading.Value.Id);
		defaultInterpolatedStringHandler.AppendLiteral("_Desc");
		instance.SetLocalTextNew(text, defaultInterpolatedStringHandler.ToStringAndClear(), Array.Empty<object>());
		LguiUtil instance2 = Singleton<LguiUtil>.Instance;
		UUIText text2 = base.GetText(4);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CharacterDisplayStyle_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleLoading.Value.Id);
		defaultInterpolatedStringHandler.AppendLiteral("_Name");
		instance2.SetLocalTextNew(text2, defaultInterpolatedStringHandler.ToStringAndClear(), Array.Empty<object>());
		base.SetTextureByPath(roleLoading.Value.IllustrationAsset, base.GetTexture(3), new EUiViewName?(this.ViewInfo.Name), null);
		ModelBase<LoadingModel>.Instance.ClearRoleLoadingInfo();
	}

	// Token: 0x06010157 RID: 65879 RVA: 0x0046A15F File Offset: 0x0046835F
	protected override void UpdateProgressRate(float rate)
	{
		base.GetSprite(0).SetFillAmount(rate);
	}

	// Token: 0x06010158 RID: 65880 RVA: 0x0046A16E File Offset: 0x0046836E
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(1, value, "%");
	}

	// Token: 0x0200845B RID: 33883
	private class EChildType
	{
		// Token: 0x0402CD82 RID: 183682
		public const int Progress = 0;

		// Token: 0x0402CD83 RID: 183683
		public const int ProgressText = 1;

		// Token: 0x0402CD84 RID: 183684
		public const int Tips = 2;

		// Token: 0x0402CD85 RID: 183685
		public const int RoleTexture = 3;

		// Token: 0x0402CD86 RID: 183686
		public const int RoleName = 4;
	}
}
