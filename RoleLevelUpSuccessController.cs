using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x02002899 RID: 10393
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleLevelUpSuccessController : UiControllerBase<RoleLevelUpSuccessController>
{
	// Token: 0x0601494E RID: 84302 RVA: 0x005B2DD4 File Offset: 0x005B0FD4
	public void OpenSuccessAttributeView(ILevelUpSuccessAttributeData data, [Nullable(2)] Action finishCallback = null)
	{
		TOpenViewCallBack finishCallback2 = delegate(bool success, int viewId)
		{
			Action finishCallback3 = finishCallback;
			if (finishCallback3 == null)
			{
				return;
			}
			finishCallback3();
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleLevelUpSuccessAttributeView, data, finishCallback2);
	}

	// Token: 0x0601494F RID: 84303 RVA: 0x005B2E0C File Offset: 0x005B100C
	[NullableContext(2)]
	public void OpenSuccessEffectView(ILevelUpSuccessEffectData data = null, Action finishCallback = null)
	{
		ILevelUpSuccessEffectData param = data ?? new LevelUpSuccessEffectData();
		TOpenViewCallBack finishCallback2 = delegate(bool success, int viewId)
		{
			Action finishCallback3 = finishCallback;
			if (finishCallback3 == null)
			{
				return;
			}
			finishCallback3();
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleLevelUpSuccessEffectView, param, finishCallback2);
	}

	// Token: 0x06014950 RID: 84304 RVA: 0x005B2E50 File Offset: 0x005B1050
	public static IAttributeInfo ConvertsAttrListScrollDataToAttributeInfo(AttrListScrollData attrData)
	{
		AttributeInfo attributeInfo = new AttributeInfo();
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrData.Id);
		attributeInfo.Name = propertyIndexInfo.Value.Name;
		attributeInfo.IconPath = propertyIndexInfo.Value.Icon;
		attributeInfo.ShowArrow = new bool?(true);
		attributeInfo.PreText = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, attrData.BaseValue, attrData.IsRatio);
		attributeInfo.CurText = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrData.Id, attrData.AddValue, attrData.IsRatio);
		return attributeInfo;
	}
}
