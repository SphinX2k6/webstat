using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002014 RID: 8212
public abstract class AttributeItemData : ItemDataBase
{
	// Token: 0x0600F949 RID: 63817 RVA: 0x00445746 File Offset: 0x00443946
	public AttributeItemData(int configId, int uniqueId, int functionValue, InventoryDefine.EItemDataType itemDataType) : base(configId, 1, itemDataType)
	{
		this.UniqueId = uniqueId;
		this.FunctionValue = functionValue;
	}

	// Token: 0x0600F94A RID: 63818 RVA: 0x00445760 File Offset: 0x00443960
	public override int GetUniqueId()
	{
		return this.UniqueId;
	}

	// Token: 0x0600F94B RID: 63819 RVA: 0x00445768 File Offset: 0x00443968
	public void SetFunctionValue(int functionValue)
	{
		this.FunctionValue = functionValue;
		this.OnSetFunctionValue(functionValue);
	}

	// Token: 0x0600F94C RID: 63820 RVA: 0x00445778 File Offset: 0x00443978
	protected virtual void OnSetFunctionValue(int functionValue)
	{
	}

	// Token: 0x0600F94D RID: 63821 RVA: 0x0044577A File Offset: 0x0044397A
	public bool IsFunctionValue(InventoryDefine.EItemDataFunctionType functionType)
	{
		return (this.FunctionValue & 1 << (int)functionType) > 0;
	}

	// Token: 0x0600F94E RID: 63822 RVA: 0x0044578C File Offset: 0x0044398C
	public override bool GetIsLock()
	{
		return this.IsFunctionValue(InventoryDefine.EItemDataFunctionType.Lock);
	}

	// Token: 0x0600F94F RID: 63823 RVA: 0x00445795 File Offset: 0x00443995
	public override bool GetIsDeprecated()
	{
		return this.IsFunctionValue(InventoryDefine.EItemDataFunctionType.Deprecate);
	}

	// Token: 0x0600F950 RID: 63824 RVA: 0x0044579E File Offset: 0x0044399E
	public InventoryDefine.EItemDataFunctionValue GetFunctionValueType()
	{
		return (InventoryDefine.EItemDataFunctionValue)this.FunctionValue;
	}

	// Token: 0x0600F951 RID: 63825 RVA: 0x004457A6 File Offset: 0x004439A6
	[NullableContext(1)]
	public virtual string GetDefaultDownText()
	{
		return "";
	}

	// Token: 0x0600F952 RID: 63826 RVA: 0x004457AD File Offset: 0x004439AD
	public override int GetUseCountLimit()
	{
		return 1;
	}

	// Token: 0x0600F953 RID: 63827 RVA: 0x004457B0 File Offset: 0x004439B0
	public override bool HasRedDot()
	{
		int uniqueId = this.GetUniqueId();
		return ModelBase<InventoryModel>.Instance.IsAttributeItemHasRedDot(uniqueId);
	}

	// Token: 0x0600F954 RID: 63828 RVA: 0x004457CF File Offset: 0x004439CF
	public override bool IsValid()
	{
		return true;
	}

	// Token: 0x04007804 RID: 30724
	private const int ATTRIBUTE_ITEM_DEFAULT_COUNT = 1;

	// Token: 0x04007805 RID: 30725
	protected readonly int UniqueId;

	// Token: 0x04007806 RID: 30726
	private int FunctionValue;
}
