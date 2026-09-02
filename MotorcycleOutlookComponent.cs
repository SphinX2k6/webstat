using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

// Token: 0x0200329D RID: 12957
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleOutlookComponent : BaseOutlookComponent
{
	// Token: 0x0601B27C RID: 111228 RVA: 0x00827D6C File Offset: 0x00825F6C
	private void OnSoarTagChanged(int tagId, bool tagExist)
	{
		if (tagExist)
		{
			if (this.SoarWingVisibleTags.Contains(tagId))
			{
				return;
			}
			this.SoarWingVisibleTags.Add(tagId);
		}
		else
		{
			if (!this.SoarWingVisibleTags.Contains(tagId))
			{
				return;
			}
			this.SoarWingVisibleTags.Remove(tagId);
		}
		if (this.SoarWingDecoration == null)
		{
			return;
		}
		if (!(tagExist ? (this.SoarWingVisibleTags.Count == 1) : (this.SoarWingVisibleTags.Count == 0)))
		{
			return;
		}
		if (this.DisableSoarWingTimer != null)
		{
			TimerSystem.Instance.Remove(this.DisableSoarWingTimer);
			this.DisableSoarWingTimer = null;
		}
		if (tagExist)
		{
			USkeletalMeshComponent meshComp = this.SoarWingDecoration.MeshComp;
			if (meshComp != null)
			{
				UAnimInstance animInstance = meshComp.GetAnimInstance();
				if (animInstance != null)
				{
					animInstance.SyncAnimStates(null);
				}
			}
			this.SoarWingDecoration.SetVisible(true, "Motorcycle.OnSoarTagExist true");
			return;
		}
		this.DisableSoarWingTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			if (this.SoarWingVisibleTags.Count > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "[Decoration][Motor] 不可以隐藏翱翔翼";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tags", JsonSerializer.Serialize<HashSet<int>>(this.SoarWingVisibleTags, null));
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<Log>.Instance.Warn(ELogModule.Test, ELogAuthor.LCZ, "[Decoration][Motor] 翱翔翼由计时器触发了隐藏", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SoarWingDecoration.SetVisible(false, "Motorcycle.OnSoarTagExist false");
		}, 1200f, null, null, true, 1f);
	}

	// Token: 0x0601B27D RID: 111229 RVA: 0x00827E68 File Offset: 0x00826068
	[NullableContext(1)]
	private void OnVehicleEntered(VehiclePassengerInfo info, bool byChangeRole)
	{
		if (byChangeRole)
		{
			return;
		}
		if (this.SoarWingVisibleTags.Count > 0)
		{
			DecorationItem soarWingDecoration = this.SoarWingDecoration;
			if (soarWingDecoration != null)
			{
				USkeletalMeshComponent meshComp = soarWingDecoration.MeshComp;
				if (meshComp != null)
				{
					UAnimInstance animInstance = meshComp.GetAnimInstance();
					if (animInstance != null)
					{
						animInstance.SyncAnimStates(null);
					}
				}
			}
			DecorationItem soarWingDecoration2 = this.SoarWingDecoration;
			if (soarWingDecoration2 == null)
			{
				return;
			}
			soarWingDecoration2.SetVisible(true, "Motorcycle.OnVehicleEntered true");
			return;
		}
		else
		{
			DecorationItem soarWingDecoration3 = this.SoarWingDecoration;
			if (soarWingDecoration3 == null)
			{
				return;
			}
			soarWingDecoration3.SetVisible(false, "Motorcycle.OnVehicleEntered false");
			return;
		}
	}

	// Token: 0x0601B27E RID: 111230 RVA: 0x00827EE0 File Offset: 0x008260E0
	protected override bool OnStart()
	{
		VehicleActorComponent component = base.Entity.GetComponent<VehicleActorComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		if (component != null)
		{
			this.SkelMeshComp = component.Actor.Mesh;
			this.CharRenderComp = component.Actor.CharRenderingComponent;
			Singleton<Log>.Instance.Info(ELogModule.Decoration, ELogAuthor.LCZ, "[Decoration][Motor] EquipMotor OnStart", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InitMotorWingId();
			this.EquipMotor(component.CreatureData.MotorOutlookInfo);
		}
		Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleEntered));
		return true;
	}

	// Token: 0x0601B27F RID: 111231 RVA: 0x00827F88 File Offset: 0x00826188
	private void InitMotorWingId()
	{
		VehicleActorComponent component = base.Entity.GetComponent<VehicleActorComponent>();
		if (((component != null) ? component.CreatureData.MotorOutlookInfo : null) != null)
		{
			MotorFrame? config = ConfigMotorFrameById.GetConfig(component.CreatureData.MotorOutlookInfo.FrameEquipped, true);
			if (config != null)
			{
				this.MotorWingId = config.Value.Wing;
				return;
			}
		}
		this.MotorWingId = 800001;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Decoration;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "[Decoration][Motor] 初始化摩托翱翔翼失败，使用默认ID";
		string item = "Frame";
		int? num;
		if (component == null)
		{
			num = null;
		}
		else
		{
			MotorOutlookEquippedPb motorOutlookInfo = component.CreatureData.MotorOutlookInfo;
			num = ((motorOutlookInfo != null) ? new int?(motorOutlookInfo.FrameEquipped) : null);
		}
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, num);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601B280 RID: 111232 RVA: 0x00828058 File Offset: 0x00826258
	protected override bool OnEnd()
	{
		if (this.SkelMeshComp != null)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"], new BaseTagComponent.TTagSwitchedCallback(this.OnSoarTagChanged));
			}
			BaseTagComponent tagComp2 = this.TagComp;
			if (tagComp2 != null)
			{
				tagComp2.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.外观状态.显示翱翔翼"], new BaseTagComponent.TTagSwitchedCallback(this.OnSoarTagChanged));
			}
		}
		if (this.DisableSoarWingTimer != null)
		{
			TimerSystem.Instance.Remove(this.DisableSoarWingTimer);
			this.DisableSoarWingTimer = null;
		}
		this.SoarWingVisibleTags.Clear();
		Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleEntered));
		return true;
	}

	// Token: 0x0601B281 RID: 111233 RVA: 0x00828114 File Offset: 0x00826314
	protected override void OnActivate()
	{
		this.SoarWingVisibleTags.Clear();
		if (this.DisableSoarWingTimer != null)
		{
			TimerSystem.Instance.Remove(this.DisableSoarWingTimer);
			this.DisableSoarWingTimer = null;
		}
		if (this.SkelMeshComp != null)
		{
			this.SoarWingDecoration = base.CreateDecorationItem(this.SkelMeshComp, 101, false, true);
			this.SoarWingDecoration.SetDecorationId(this.MotorWingId);
			if (this.TagComp != null)
			{
				if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]))
				{
					this.SoarWingVisibleTags.Add(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]);
				}
				if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.外观状态.显示翱翔翼"]))
				{
					this.SoarWingVisibleTags.Add(GameplayTagDefine.EGameplayTagId["载具.摩托.外观状态.显示翱翔翼"]);
				}
				if (this.SoarWingVisibleTags.Count > 0)
				{
					USkeletalMeshComponent meshComp = this.SoarWingDecoration.MeshComp;
					if (meshComp != null)
					{
						UAnimInstance animInstance = meshComp.GetAnimInstance();
						if (animInstance != null)
						{
							animInstance.SyncAnimStates(null);
						}
					}
					this.SoarWingDecoration.SetVisible(true, "Motorcycle.OnActivate true");
				}
				else
				{
					this.SoarWingDecoration.SetVisible(false, "Motorcycle.OnActivate false");
				}
				this.TagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"], new BaseTagComponent.TTagSwitchedCallback(this.OnSoarTagChanged), null);
				this.TagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.外观状态.显示翱翔翼"], new BaseTagComponent.TTagSwitchedCallback(this.OnSoarTagChanged), null);
			}
		}
	}

	// Token: 0x0601B282 RID: 111234 RVA: 0x0082829B File Offset: 0x0082649B
	public bool EquipMotor(MotorOutlookEquippedPb equippedPd)
	{
		base.EquipDecoration((equippedPd != null) ? equippedPd.DecorationsEquipped.ToList<int>() : null);
		return this.EquipMotorSticker((equippedPd != null) ? equippedPd.StickerEquipped.ToList<int>() : null);
	}

	// Token: 0x0601B283 RID: 111235 RVA: 0x008282CC File Offset: 0x008264CC
	[NullableContext(1)]
	protected override void AddRenderMesh(DecorationItem item)
	{
		CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
		if (component != null && item.MeshComp != null)
		{
			component.Actor.CharRenderingComponent.AddComponent(item.MeshComp.GetName(), item.MeshComp);
		}
		MotorcycleActorComponent component2 = base.Entity.GetComponent<MotorcycleActorComponent>();
		if (component2 != null && item.MeshComp != null)
		{
			component2.VehicleOwner.CharRenderingComponent.AddComponent(item.MeshComp.GetName(), item.MeshComp);
		}
	}

	// Token: 0x0601B284 RID: 111236 RVA: 0x0082834C File Offset: 0x0082654C
	protected override int? GetDecorationModelId(int decorationId)
	{
		MotorDecorations? config = ConfigMotorDecorationsById.GetConfig(decorationId, true);
		if (config == null)
		{
			return null;
		}
		return new int?(config.GetValueOrDefault().ModelId);
	}

	// Token: 0x0601B285 RID: 111237 RVA: 0x00828388 File Offset: 0x00826588
	public unsafe bool EquipMotorSticker(List<int> stickerIds)
	{
		List<int> list = stickerIds ?? new List<int>();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Decoration;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "[Decoration][Motor] Equip MotorStickers";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("length", list.Count);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		for (int i = 0; i < list.Count; i++)
		{
			if (this.CurrentStickers.Count <= i)
			{
				this.CurrentStickers.Add(new MotorcycleOutlookComponent.StickerParams(0, 0));
			}
			MotorcycleOutlookComponent.StickerParams stickerParams = this.CurrentStickers[i];
			int num = list[i];
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Decoration;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "[Decoration][Motor] Equip MotorSticker";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", i);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("From", stickerParams.StickerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("To", num);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (stickerParams.StickerId != num)
			{
				if (stickerParams.PdHandle != 0)
				{
					CharRenderingComponent charRenderComp = this.CharRenderComp;
					if (charRenderComp != null)
					{
						charRenderComp.RemoveMaterialControllerData(stickerParams.PdHandle);
					}
					stickerParams.PdHandle = 0;
				}
				stickerParams.StickerId = num;
				if (num != 0)
				{
					MotorSticker? config = ConfigMotorStickerById.GetConfig(num, true);
					if (((config != null) ? config.GetValueOrDefault().MaterialDA : null) != null)
					{
						PD_CharacterControllerData_C pd_CharacterControllerData_C = Singleton<ResourceSystem>.Instance.Load<PD_CharacterControllerData_C>(config.Value.MaterialDA, "js_undefined");
						if (pd_CharacterControllerData_C != null)
						{
							MotorcycleOutlookComponent.StickerParams stickerParams2 = stickerParams;
							CharRenderingComponent charRenderComp2 = this.CharRenderComp;
							stickerParams2.PdHandle = ((charRenderComp2 != null) ? charRenderComp2.AddMaterialControllerData(pd_CharacterControllerData_C) : 0);
						}
						else
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.Decoration;
							ELogAuthor author3 = ELogAuthor.LCZ;
							string message3 = "[Decoration][Motor] Motor CharCtrl not found.";
							ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", (config != null) ? config.GetValueOrDefault().MaterialDA : null);
							instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						}
					}
					else
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Decoration;
						ELogAuthor author4 = ELogAuthor.LCZ;
						string message4 = "[Decoration][Motor] Motor stickerId not found.";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Id", num);
						instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					}
				}
			}
		}
		for (int j = list.Count; j < this.CurrentStickers.Count; j++)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Decoration;
			ELogAuthor author5 = ELogAuthor.LCZ;
			string message5 = "[Decoration][Motor] EquipMotor Clear";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("Index", j);
			instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			MotorcycleOutlookComponent.StickerParams stickerParams3 = this.CurrentStickers[j];
			if (stickerParams3.PdHandle != 0)
			{
				CharRenderingComponent charRenderComp3 = this.CharRenderComp;
				if (charRenderComp3 != null)
				{
					charRenderComp3.RemoveMaterialControllerData(stickerParams3.PdHandle);
				}
				stickerParams3.PdHandle = 0;
			}
			stickerParams3.StickerId = 0;
		}
		return true;
	}

	// Token: 0x0601B286 RID: 111238 RVA: 0x00828668 File Offset: 0x00826868
	public void DisableSoarWing()
	{
		if (this.SoarWingVisibleTags.Count > 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "[Decoration][Motor] 不可以隐藏翱翔翼";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tags", JsonSerializer.Serialize<HashSet<int>>(this.SoarWingVisibleTags, null));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.DisableSoarWingTimer != null)
		{
			TimerSystem.Instance.Remove(this.DisableSoarWingTimer);
			this.DisableSoarWingTimer = null;
		}
		DecorationItem soarWingDecoration = this.SoarWingDecoration;
		if (soarWingDecoration == null)
		{
			return;
		}
		soarWingDecoration.SetVisible(false, "Motorcycle.DisableSoarWing");
	}

	// Token: 0x0601B287 RID: 111239 RVA: 0x008286EC File Offset: 0x008268EC
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleOutlookComponent motorcycleOutlookComponent = (MotorcycleOutlookComponent)componentTemplate;
		if (base.CanResetComponentProperty("MotorWingId"))
		{
			this.MotorWingId = motorcycleOutlookComponent.MotorWingId;
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (motorcycleOutlookComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharRenderComp"))
		{
			if (motorcycleOutlookComponent.CharRenderComp == null)
			{
				this.CharRenderComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharRenderingComponent>(this.CharRenderComp), "CharRenderComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurrentStickers"))
		{
			if (motorcycleOutlookComponent.CurrentStickers == null)
			{
				this.CurrentStickers = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<MotorcycleOutlookComponent.StickerParams>>(this.CurrentStickers), "CurrentStickers"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SoarWingDecoration"))
		{
			if (motorcycleOutlookComponent.SoarWingDecoration == null)
			{
				this.SoarWingDecoration = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DecorationItem>(this.SoarWingDecoration), "SoarWingDecoration"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DisableSoarWingTimer"))
		{
			if (motorcycleOutlookComponent.DisableSoarWingTimer == null)
			{
				this.DisableSoarWingTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.DisableSoarWingTimer), "DisableSoarWingTimer"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("SoarWingVisibleTags") || motorcycleOutlookComponent.SoarWingVisibleTags == null || base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.SoarWingVisibleTags), "SoarWingVisibleTags");
	}

	// Token: 0x0400DD25 RID: 56613
	private const int SOAR_WING_INDEX = 101;

	// Token: 0x0400DD26 RID: 56614
	private const int SOAR_WING_ID = 800001;

	// Token: 0x0400DD27 RID: 56615
	private const long SOAR_WING_HIDE_DELAY = 1200L;

	// Token: 0x0400DD28 RID: 56616
	private int MotorWingId = 800001;

	// Token: 0x0400DD29 RID: 56617
	protected BaseTagComponent TagComp;

	// Token: 0x0400DD2A RID: 56618
	protected CharRenderingComponent CharRenderComp;

	// Token: 0x0400DD2B RID: 56619
	[Nullable(1)]
	protected List<MotorcycleOutlookComponent.StickerParams> CurrentStickers = new List<MotorcycleOutlookComponent.StickerParams>();

	// Token: 0x0400DD2C RID: 56620
	protected DecorationItem SoarWingDecoration;

	// Token: 0x0400DD2D RID: 56621
	private TimerHandle DisableSoarWingTimer;

	// Token: 0x0400DD2E RID: 56622
	[Nullable(1)]
	private readonly HashSet<int> SoarWingVisibleTags = new HashSet<int>();

	// Token: 0x02009467 RID: 37991
	[NullableContext(0)]
	protected class StickerParams
	{
		// Token: 0x0604A377 RID: 303991 RVA: 0x0141AE5F File Offset: 0x0141905F
		public StickerParams(int inStickerId, int inPdHandle = 0)
		{
			this.StickerId = inStickerId;
			this.PdHandle = inPdHandle;
		}

		// Token: 0x040313E6 RID: 201702
		public int StickerId;

		// Token: 0x040313E7 RID: 201703
		public int PdHandle;
	}
}
