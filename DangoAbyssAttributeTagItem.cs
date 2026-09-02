using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AD2 RID: 6866
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssAttributeTagItem : UiPanelBase
{
	// Token: 0x0600C59B RID: 50587 RVA: 0x003431AC File Offset: 0x003413AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600C59C RID: 50588 RVA: 0x00343206 File Offset: 0x00341406
	public void Initialize(UUIItem uiItem)
	{
		base.CreateByActorAsync(uiItem.GetOwner(), null, false).Forget();
	}

	// Token: 0x0600C59D RID: 50589 RVA: 0x0034321B File Offset: 0x0034141B
	protected override void OnStart()
	{
		this.Sequence = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600C59E RID: 50590 RVA: 0x00343230 File Offset: 0x00341430
	public void Refresh(DangoAbyssDefine.EquipViewAttributeData data)
	{
		DangoAbyssDefine.DangoAbyssTagData tag = data.Tag;
		AbyssPluginPropDesc value = ConfigBase<DangoAbyssConfig>.Instance.GetDangoPluginPropDescById(tag.TagId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Name, Array.Empty<object>());
		FColor color = FColor.FromHex(value.BgColor);
		base.GetSprite(0).SetColor(color);
		string formatAttributeValueByTagId = ModelBase<DangoAbyssModel>.Instance.GetFormatAttributeValueByTagId(tag.Value, tag.TagId, null);
		base.GetText(2).SetText(formatAttributeValueByTagId, true);
		base.SetUiActive(true);
		if (data.IsChange)
		{
			this.PlaySequence("Change").Forget();
		}
	}

	// Token: 0x0600C59F RID: 50591 RVA: 0x003432E4 File Offset: 0x003414E4
	public UniTask PlaySequence(string name)
	{
		DangoAbyssAttributeTagItem.<PlaySequence>d__6 <PlaySequence>d__;
		<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequence>d__.<>4__this = this;
		<PlaySequence>d__.name = name;
		<PlaySequence>d__.<>1__state = -1;
		<PlaySequence>d__.<>t__builder.Start<DangoAbyssAttributeTagItem.<PlaySequence>d__6>(ref <PlaySequence>d__);
		return <PlaySequence>d__.<>t__builder.Task;
	}

	// Token: 0x04005EB3 RID: 24243
	[Nullable(2)]
	public LevelSequencePlayer Sequence;

	// Token: 0x02007DA5 RID: 32165
	[NullableContext(0)]
	private enum ETagItemComponent
	{
		// Token: 0x0402ACB0 RID: 175280
		SpriteBg,
		// Token: 0x0402ACB1 RID: 175281
		TextName,
		// Token: 0x0402ACB2 RID: 175282
		TextValue
	}
}
