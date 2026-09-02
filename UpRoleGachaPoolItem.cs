using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CF5 RID: 7413
public class UpRoleGachaPoolItem : GachaPoolItem
{
	// Token: 0x0600D9A1 RID: 55713 RVA: 0x003A617E File Offset: 0x003A437E
	public UpRoleGachaPoolItem(GachaDefine.EGachaViewType gachaType) : base(gachaType)
	{
	}

	// Token: 0x0600D9A2 RID: 55714 RVA: 0x003A6188 File Offset: 0x003A4388
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D9A3 RID: 55715 RVA: 0x003A6278 File Offset: 0x003A4478
	protected override UniTask OnBeforeStartAsync()
	{
		UpRoleGachaPoolItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<UpRoleGachaPoolItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D9A4 RID: 55716 RVA: 0x003A62BC File Offset: 0x003A44BC
	public override void Refresh()
	{
		if (this.GachaViewInfo == null)
		{
			return;
		}
		int gachaTextureInfoId = this.GachaViewInfo.Value.GetShowIdListArray()[0];
		this.DescComponent.Update(gachaTextureInfoId, this.GachaType.GetValueOrDefault() != GachaDefine.EGachaViewType.NewPlayerCustom);
		UUITexture contentTexture = base.GetTexture(0);
		base.SetTextureByPath(this.GachaViewInfo.Value.ContentTexturePath, contentTexture, null, delegate(bool _)
		{
			contentTexture.SetSizeFromTexture();
		});
		base.SetTextureByPath(this.GachaViewInfo.Value.TextTexture, base.GetTexture(3), null, null);
		UUITexture contentBgTexture = base.GetTexture(2);
		base.SetTextureByPath(this.GachaViewInfo.Value.ContentTextureBgPath, contentBgTexture, null, delegate(bool _)
		{
			contentBgTexture.SetSizeFromTexture();
		});
		bool flag = !StringUtils.IsBlank(this.GachaViewInfo.Value.EffectPath);
		base.GetItem(4).SetUIActive(flag);
		if (flag)
		{
			base.SetNiagaraSystemByPath(this.GachaViewInfo.Value.EffectPath, base.GetUiNiagara(5), null);
			if (this.GachaViewInfo.Value.EffectLocation != null)
			{
				base.GetItem(4).SetAnchorOffsetX(this.GachaViewInfo.Value.EffectLocation.Value.X);
				base.GetItem(4).SetAnchorOffsetY(this.GachaViewInfo.Value.EffectLocation.Value.Y);
			}
		}
	}

	// Token: 0x0600D9A5 RID: 55717 RVA: 0x003A648F File Offset: 0x003A468F
	public void SetDescUiActive(bool bActive)
	{
		this.DescComponent.SetUiActive(bActive);
	}

	// Token: 0x040067DC RID: 26588
	[Nullable(2)]
	private RoleDescribeComponent DescComponent;

	// Token: 0x02008060 RID: 32864
	private enum EComponent
	{
		// Token: 0x0402BAB9 RID: 178873
		ContentTexture,
		// Token: 0x0402BABA RID: 178874
		DescItem,
		// Token: 0x0402BABB RID: 178875
		ContentBgTexture,
		// Token: 0x0402BABC RID: 178876
		ThemeTextTexture,
		// Token: 0x0402BABD RID: 178877
		EffectPanel,
		// Token: 0x0402BABE RID: 178878
		EffectNiagara
	}
}
