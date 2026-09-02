using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D1A RID: 7450
[NullableContext(1)]
[Nullable(0)]
public class KurotatoAttrChangePanel : UiPanelBase
{
	// Token: 0x0600DAEE RID: 56046 RVA: 0x003AC8E0 File Offset: 0x003AAAE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600DAEF RID: 56047 RVA: 0x003AC93C File Offset: 0x003AAB3C
	protected override void OnStart()
	{
		this.AttrLayout = new GenericLayout<KurotatoAttrChangeItem, IKurotatoAttrChangeData>(base.GetVerticalLayout(1), () => new KurotatoAttrChangeItem(), null, false, true);
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600DAF0 RID: 56048 RVA: 0x003AC9A8 File Offset: 0x003AABA8
	public void ShowLevelUp()
	{
		base.SetUiActive(true);
		base.GetText(0).SetUIActive(true);
		this.LevelHideTimer = 3000f;
		this.SeqPlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0600DAF1 RID: 56049 RVA: 0x003AC9F0 File Offset: 0x003AABF0
	public void ShowAttrChange(IDictionary<int, int> propertyValues)
	{
		foreach (KeyValuePair<int, int> keyValuePair in propertyValues)
		{
			int key = keyValuePair.Key;
			int systemPropertyValue = ModelBase<KurotatoModel>.Instance.GetSystemPropertyValue(key);
			int num = keyValuePair.Value - systemPropertyValue;
			if (num != 0)
			{
				KurotatoProperty? propertyById = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(key);
				if (propertyById != null && !propertyById.Value.IsBlockFloat)
				{
					string str = (num >= 0) ? "+" : "-";
					string propertyShowValue = KurotatoUtil.GetPropertyShowValue(key, (float)Math.Abs(num));
					string str2 = ConfigMultiTextLang.GetLocalTextNew(propertyById.Value.ShowName, null) ?? propertyById.Value.ShowName;
					string str3 = KurotatoUtil.WrapAttrValueColor(str + propertyShowValue, (float)num, (float)propertyById.Value.BasicValue);
					this.AttrQueue.Add(new KurotatoAttrChangeData
					{
						Text = str2 + " " + str3,
						IconPath = propertyById.Value.Icon
					});
				}
			}
		}
		if (this.AttrQueue.Count == 0)
		{
			return;
		}
		if (this.AttrQueue.Count > 3)
		{
			this.AttrQueue.RemoveRange(0, this.AttrQueue.Count - 3);
		}
		this.AttrLayout.RefreshByData(this.AttrQueue, null, false);
		this.AttrHideTimer = 3000f;
	}

	// Token: 0x0600DAF2 RID: 56050 RVA: 0x003ACB94 File Offset: 0x003AAD94
	public void OnTick(float dt)
	{
		if (this.LevelHideTimer > 0f)
		{
			this.LevelHideTimer -= dt;
			if (this.LevelHideTimer <= 0f)
			{
				base.GetText(0).SetUIActive(false);
			}
		}
		if (this.AttrHideTimer > 0f)
		{
			this.AttrHideTimer -= dt;
			if (this.AttrHideTimer <= 0f)
			{
				this.AttrQueue.Clear();
				base.GetVerticalLayout(1).RootUIComp.Get().SetUIActive(false);
			}
		}
		if (this.LevelHideTimer <= 0f && this.AttrHideTimer <= 0f)
		{
			base.SetUiActive(false);
		}
	}

	// Token: 0x04006877 RID: 26743
	private const int MAX_ATTR_COUNT = 3;

	// Token: 0x04006878 RID: 26744
	private const float HIDE_DELAY = 3000f;

	// Token: 0x04006879 RID: 26745
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<KurotatoAttrChangeItem, IKurotatoAttrChangeData> AttrLayout;

	// Token: 0x0400687A RID: 26746
	private readonly List<IKurotatoAttrChangeData> AttrQueue = new List<IKurotatoAttrChangeData>();

	// Token: 0x0400687B RID: 26747
	private float LevelHideTimer;

	// Token: 0x0400687C RID: 26748
	private float AttrHideTimer;

	// Token: 0x0400687D RID: 26749
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008091 RID: 32913
	[NullableContext(0)]
	private static class EComp
	{
		// Token: 0x0402BBA1 RID: 179105
		public const int TextLevelUp = 0;

		// Token: 0x0402BBA2 RID: 179106
		public const int PanelAttrList = 1;

		// Token: 0x0402BBA3 RID: 179107
		public const int ItemAttr = 2;
	}
}
