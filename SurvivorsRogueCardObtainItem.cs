using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002ADB RID: 10971
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRogueCardObtainItem : SurvivorsRogueCardScrollItemBase<GoodsDetail>
{
	// Token: 0x06015F03 RID: 89859 RVA: 0x006181A0 File Offset: 0x006163A0
	public override UniTask RefreshAsync(GoodsDetail data, bool isSelected, int gridIndex)
	{
		SurvivorsRogueCardObtainItem.<RefreshAsync>d__1 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.isSelected = isSelected;
		<RefreshAsync>d__.gridIndex = gridIndex;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<SurvivorsRogueCardObtainItem.<RefreshAsync>d__1>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015F04 RID: 89860 RVA: 0x006181FC File Offset: 0x006163FC
	private UniTask RefreshRoleLv(Aki.Protocol.SurvivorsGainData gainData, int gridIndex)
	{
		SurvivorsRogueCardObtainItem.<RefreshRoleLv>d__2 <RefreshRoleLv>d__;
		<RefreshRoleLv>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleLv>d__.<>4__this = this;
		<RefreshRoleLv>d__.gainData = gainData;
		<RefreshRoleLv>d__.gridIndex = gridIndex;
		<RefreshRoleLv>d__.<>1__state = -1;
		<RefreshRoleLv>d__.<>t__builder.Start<SurvivorsRogueCardObtainItem.<RefreshRoleLv>d__2>(ref <RefreshRoleLv>d__);
		return <RefreshRoleLv>d__.<>t__builder.Task;
	}

	// Token: 0x06015F05 RID: 89861 RVA: 0x00618250 File Offset: 0x00616450
	private UniTask RefreshWeaponLv(Aki.Protocol.SurvivorsGainData gainData, int gridIndex)
	{
		SurvivorsRogueCardObtainItem.<RefreshWeaponLv>d__3 <RefreshWeaponLv>d__;
		<RefreshWeaponLv>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshWeaponLv>d__.<>4__this = this;
		<RefreshWeaponLv>d__.gainData = gainData;
		<RefreshWeaponLv>d__.gridIndex = gridIndex;
		<RefreshWeaponLv>d__.<>1__state = -1;
		<RefreshWeaponLv>d__.<>t__builder.Start<SurvivorsRogueCardObtainItem.<RefreshWeaponLv>d__3>(ref <RefreshWeaponLv>d__);
		return <RefreshWeaponLv>d__.<>t__builder.Task;
	}

	// Token: 0x06015F06 RID: 89862 RVA: 0x006182A4 File Offset: 0x006164A4
	private UniTask RefreshNewWeapon(Aki.Protocol.SurvivorsGainData gainData, int gridIndex)
	{
		SurvivorsRogueCardObtainItem.<RefreshNewWeapon>d__4 <RefreshNewWeapon>d__;
		<RefreshNewWeapon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNewWeapon>d__.<>4__this = this;
		<RefreshNewWeapon>d__.gainData = gainData;
		<RefreshNewWeapon>d__.gridIndex = gridIndex;
		<RefreshNewWeapon>d__.<>1__state = -1;
		<RefreshNewWeapon>d__.<>t__builder.Start<SurvivorsRogueCardObtainItem.<RefreshNewWeapon>d__4>(ref <RefreshNewWeapon>d__);
		return <RefreshNewWeapon>d__.<>t__builder.Task;
	}

	// Token: 0x06015F07 RID: 89863 RVA: 0x006182F8 File Offset: 0x006164F8
	private UniTask RefreshNewItem(Aki.Protocol.SurvivorsGainData gainData, int gridIndex)
	{
		SurvivorsRogueCardObtainItem.<RefreshNewItem>d__5 <RefreshNewItem>d__;
		<RefreshNewItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNewItem>d__.<>4__this = this;
		<RefreshNewItem>d__.gainData = gainData;
		<RefreshNewItem>d__.gridIndex = gridIndex;
		<RefreshNewItem>d__.<>1__state = -1;
		<RefreshNewItem>d__.<>t__builder.Start<SurvivorsRogueCardObtainItem.<RefreshNewItem>d__5>(ref <RefreshNewItem>d__);
		return <RefreshNewItem>d__.<>t__builder.Task;
	}

	// Token: 0x06015F08 RID: 89864 RVA: 0x0061834B File Offset: 0x0061654B
	public override void OnSelected(bool fireEvent)
	{
		base.SetSelected(true, fireEvent, false);
	}

	// Token: 0x06015F09 RID: 89865 RVA: 0x00618356 File Offset: 0x00616556
	public override void OnDeselected(bool fireEvent)
	{
		base.SetSelected(false, fireEvent, false);
	}

	// Token: 0x06015F0A RID: 89866 RVA: 0x00618361 File Offset: 0x00616561
	public override object GetKey(GoodsDetail data, int gridIndex)
	{
		return data.SurvivorsGainData.IncId;
	}

	// Token: 0x0400A893 RID: 43155
	protected GoodsDetail GoodData;
}
