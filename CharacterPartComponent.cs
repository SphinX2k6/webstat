using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x0200305E RID: 12382
[NullableContext(2)]
[Nullable(0)]
public class CharacterPartComponent : EntityComponent
{
	// Token: 0x1700224A RID: 8778
	// (get) Token: 0x0601970E RID: 104206 RVA: 0x0075A021 File Offset: 0x00758221
	public bool IsMultiPart
	{
		get
		{
			return this.IsMultiPartInternal;
		}
	}

	// Token: 0x0601970F RID: 104207 RVA: 0x0075A02C File Offset: 0x0075822C
	protected override bool OnInitData(IEntityArgs args = null)
	{
		EntityComponentPb entityComponentPb;
		if (base.Entity.GetComponent<CreatureDataComponent>().ComponentDataMap.TryGetValue("PartComponent", out entityComponentPb))
		{
			this.PartComponentPb = ((entityComponentPb != null) ? entityComponentPb.PartComponent : null);
		}
		this.Parts = new CharacterPart[0];
		this.PartMapByBone = new Dictionary<string, CharacterPart>();
		this.PartMapByTag = new Dictionary<string, CharacterPart>();
		this.GroupMapByBone = new Dictionary<string, string>();
		this.WeaknessByBone = new Dictionary<string, CharacterPart>();
		this.PartForwardByBone = new Dictionary<string, string>();
		this.PartActiveTagChangeTaskList = new ITagTask[0];
		return true;
	}

	// Token: 0x06019710 RID: 104208 RVA: 0x0075A0B9 File Offset: 0x007582B9
	protected override bool OnInit()
	{
		this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
		TsBaseCharacter actor = base.Entity.GetComponent<CharacterActorComponent>().Actor;
		if (((actor != null) ? actor.DtCharacterPart : null) != null)
		{
			this.IsMultiPartInternal = true;
		}
		return true;
	}

	// Token: 0x06019711 RID: 104209 RVA: 0x0075A0F4 File Offset: 0x007582F4
	protected unsafe override void OnActivate()
	{
		if (!this.IsMultiPartInternal)
		{
			return;
		}
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.BaseChar = this.ActorComp.Actor;
		this.DtCharacterPart = this.BaseChar.DtCharacterPart;
		List<SCharacterPart> dataTableAllRowFromTable = DataTableUtil.GetDataTableAllRowFromTable<SCharacterPart>(this.DtCharacterPart);
		PartComponentPb partComponentPb = this.PartComponentPb;
		List<CharacterPart> list = new List<CharacterPart>();
		List<ITagTask> list2 = new List<ITagTask>();
		for (int i = 0; i < dataTableAllRowFromTable.Count; i++)
		{
			SCharacterPart scharacterPart = dataTableAllRowFromTable[i];
			CharacterPart characterPart = new CharacterPart(base.Entity, i, scharacterPart);
			list.Add(characterPart);
			this.PartMapByBone.Add(scharacterPart.部位名, characterPart);
			int num = scharacterPart.骨骼名.Num();
			bool isWeakness = characterPart.IsWeakness;
			for (int j = 0; j < num; j++)
			{
				string key = scharacterPart.骨骼名.Get(j);
				this.GroupMapByBone.Add(key, scharacterPart.部位名);
				if (isWeakness)
				{
					this.WeaknessByBone.Add(key, characterPart);
				}
			}
			TMap<string, string> 碰撞框朝向 = scharacterPart.碰撞框朝向;
			if (碰撞框朝向 != null)
			{
				int maxIndex = 碰撞框朝向.GetMaxIndex();
				for (int k = 0; k < maxIndex; k++)
				{
					if (碰撞框朝向.IsValidIndex(k))
					{
						string key2 = 碰撞框朝向.GetKey(k);
						string text = 碰撞框朝向.Get(key2);
						if (text != null)
						{
							this.PartForwardByBone[key2] = text;
						}
					}
				}
			}
			this.TagComponent.RemoveTag(new int?(scharacterPart.部位标签.TagId()));
			Dictionary<string, CharacterPart> partMapByTag = this.PartMapByTag;
			FGameplayTag 部位标签 = scharacterPart.部位标签;
			if (partMapByTag.ContainsKey(部位标签.TagName.ToString()))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Part;
				Entity entity = base.Entity;
				string message = "部位标签重复注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("v", scharacterPart.部位标签.TagName);
				instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			Dictionary<string, CharacterPart> partMapByTag2 = this.PartMapByTag;
			部位标签 = scharacterPart.部位标签;
			partMapByTag2.Add(部位标签.TagName.ToString(), characterPart);
			ITagTask tagTask = this.ListenCharPartActiveChange(characterPart, scharacterPart.部位激活标签);
			if (tagTask != null)
			{
				list2.Add(tagTask);
			}
			if (!FNameUtil.IsNothing(scharacterPart.合体骨骼名))
			{
				if (this.PartMapByCombineBone == null)
				{
					this.PartMapByCombineBone = new Dictionary<string, CharacterPart>();
				}
				this.PartMapByCombineBone.Add(scharacterPart.合体骨骼名.ToString(), characterPart);
			}
			if (partComponentPb == null)
			{
				if (scharacterPart.是否出生激活)
				{
					if (this.TagComponent.HasTag(scharacterPart.部位激活标签.TagId()))
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Character;
						ELogAuthor author = ELogAuthor.HCW;
						string message2 = "部位勾选了[是否出生激活]，但是在蓝图中提前加了标签，会导致标签添加时无法触发从无到有事件，引起功能失效";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("角色", this.BaseChar);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("部位", scharacterPart.部位名);
						instance2.Error(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
					this.TagComponent.AddTag(new int?(scharacterPart.部位激活标签.TagId()));
				}
				PartInformation partInformation = PartInformation.Create();
				partInformation.LifeValue = characterPart.Life;
				partInformation.LifeMax = characterPart.LifeMax;
				partInformation.PartId = characterPart.Index;
				partInformation.Activated = scharacterPart.是否出生激活;
				partInformation.PartTag = characterPart.PartTag.Value.TagId();
			}
			else
			{
				PartInformation partInformation2 = null;
				RepeatedField<PartInformation> partLifeInfos = partComponentPb.PartLifeInfos;
				for (int l = 0; l < partLifeInfos.Count; l++)
				{
					if (partLifeInfos[l].PartId == i)
					{
						partInformation2 = partLifeInfos[l];
						break;
					}
				}
				if (partInformation2 != null)
				{
					characterPart.UpdatePartInfo(partInformation2, true);
				}
			}
		}
		this.Parts = list.ToArray();
		this.PartActiveTagChangeTaskList = list2.ToArray();
	}

	// Token: 0x06019712 RID: 104210 RVA: 0x0075A4D0 File Offset: 0x007586D0
	protected override bool OnEnd()
	{
		if (this.IsMultiPartInternal)
		{
			ITagTask[] partActiveTagChangeTaskList = this.PartActiveTagChangeTaskList;
			for (int i = 0; i < partActiveTagChangeTaskList.Length; i++)
			{
				partActiveTagChangeTaskList[i].EndTask();
			}
		}
		return true;
	}

	// Token: 0x06019713 RID: 104211 RVA: 0x0075A504 File Offset: 0x00758704
	[NullableContext(1)]
	public bool IsWeakness(string boneName)
	{
		CharacterPart characterPart = this.WeaknessByBone.ContainsKey(boneName) ? this.WeaknessByBone[boneName] : null;
		return characterPart != null && characterPart.Active;
	}

	// Token: 0x06019714 RID: 104212 RVA: 0x0075A53C File Offset: 0x0075873C
	[NullableContext(1)]
	[return: Nullable(2)]
	public CharacterPart GetPart(string boneName)
	{
		string valueOrDefault = this.GroupMapByBone.GetValueOrDefault(boneName);
		if (valueOrDefault == null)
		{
			return null;
		}
		return this.PartMapByBone.GetValueOrDefault(valueOrDefault);
	}

	// Token: 0x06019715 RID: 104213 RVA: 0x0075A568 File Offset: 0x00758768
	public CharacterPart GetPartByTag(FGameplayTag tag)
	{
		CharacterPart characterPart;
		this.PartMapByTag.TryGetValue(tag.TagName.ToString(), out characterPart);
		if (characterPart == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Part;
			Entity entity = base.Entity;
			string message = "获取部位失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagName", tag.TagName);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return characterPart;
	}

	// Token: 0x06019716 RID: 104214 RVA: 0x0075A5D0 File Offset: 0x007587D0
	public CharacterPart GetPartByIndex(int index)
	{
		if (index < 0 || index >= this.Parts.Length)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Part;
			Entity entity = base.Entity;
			string message = "获取部位失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return this.Parts[index];
	}

	// Token: 0x06019717 RID: 104215 RVA: 0x0075A626 File Offset: 0x00758826
	[NullableContext(1)]
	[return: Nullable(2)]
	public CharacterPart GetPartByCombineBoneName(string boneName)
	{
		if (this.PartMapByCombineBone == null)
		{
			return null;
		}
		return this.PartMapByCombineBone.GetValueOrDefault(boneName);
	}

	// Token: 0x06019718 RID: 104216 RVA: 0x0075A640 File Offset: 0x00758840
	[NullableContext(1)]
	[return: Nullable(2)]
	private ITagTask ListenCharPartActiveChange(CharacterPart part, FGameplayTag tag)
	{
		return this.TagComponent.ListenForTagAddOrRemove(new int?(tag.TagId()), delegate(int tagId, bool bTagExists)
		{
			part.SetActive(bTagExists);
		}, null);
	}

	// Token: 0x06019719 RID: 104217 RVA: 0x0075A680 File Offset: 0x00758880
	[CombatListen(ENotifyMessageId.PartUpdateNotify, false, false)]
	public static void PartUpdateNotify(Entity entity, [Nullable(1)] PartUpdateNotify data, CombatCommon combatCommon = null)
	{
		long entityId = data.EntityId;
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
		if (entity2 == null)
		{
			return;
		}
		CharacterPartComponent component = entity2.Entity.GetComponent<CharacterPartComponent>();
		foreach (PartInformation partInformation in data.PartInfos)
		{
			CharacterPart partByIndex = component.GetPartByIndex(partInformation.PartId);
			if (partByIndex != null)
			{
				partByIndex.UpdatePartInfo(partInformation, true);
			}
		}
	}

	// Token: 0x0601971A RID: 104218 RVA: 0x0075A708 File Offset: 0x00758908
	[CombatListen(ENotifyMessageId.PartComponentInitNotify, false, false)]
	public static void PartComponentInitNotify(Entity entity, [Nullable(1)] PartComponentInitNotify data, CombatCommon combatCommon = null)
	{
		long entityId = data.EntityId;
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
		if (entity2 == null)
		{
			return;
		}
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Part, entity, "PartComponentInitNotify", default(ReadOnlySpan<ValueTuple<string, object>>));
		CharacterPartComponent component = entity2.Entity.GetComponent<CharacterPartComponent>();
		foreach (PartInformation partInformation in data.PartComponent.PartLifeInfos)
		{
			CharacterPart partByIndex = component.GetPartByIndex(partInformation.PartId);
			if (partByIndex != null)
			{
				partByIndex.UpdatePartInfo(partInformation, true);
			}
		}
	}

	// Token: 0x0601971B RID: 104219 RVA: 0x0075A7B4 File Offset: 0x007589B4
	[NullableContext(1)]
	public string GetDebugText()
	{
		string text = "";
		foreach (CharacterPart characterPart in this.Parts)
		{
			string[] array = new string[9];
			array[0] = text;
			array[1] = "\n\t\t";
			array[2] = characterPart.Index.ToString();
			array[3] = " ";
			int num = 4;
			CharacterPart characterPart2 = characterPart;
			array[num] = ((characterPart2.PartTag != null) ? new FName?(characterPart2.PartTag.GetValueOrDefault().TagName) : null).ToString();
			array[5] = " : ";
			array[6] = characterPart.Life.ToString();
			array[7] = ", ";
			array[8] = characterPart.Active.ToString();
			text = string.Concat(array);
		}
		return text;
	}

	// Token: 0x0601971C RID: 104220 RVA: 0x0075A880 File Offset: 0x00758A80
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterPartComponent characterPartComponent = (CharacterPartComponent)componentTemplate;
		if (base.CanResetComponentProperty("BaseChar"))
		{
			if (characterPartComponent.BaseChar == null)
			{
				this.BaseChar = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.BaseChar), "BaseChar"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterPartComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (characterPartComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DtCharacterPart"))
		{
			if (characterPartComponent.DtCharacterPart == null)
			{
				this.DtCharacterPart = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UDataTable>(this.DtCharacterPart), "DtCharacterPart"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Parts"))
		{
			if (characterPartComponent.Parts == null)
			{
				this.Parts = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterPart[]>(this.Parts), "Parts"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartMapByBone"))
		{
			if (characterPartComponent.PartMapByBone == null)
			{
				this.PartMapByBone = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, CharacterPart>>(this.PartMapByBone), "PartMapByBone"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartMapByTag"))
		{
			if (characterPartComponent.PartMapByTag == null)
			{
				this.PartMapByTag = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, CharacterPart>>(this.PartMapByTag), "PartMapByTag"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WeaknessByBone"))
		{
			if (characterPartComponent.WeaknessByBone == null)
			{
				this.WeaknessByBone = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, CharacterPart>>(this.WeaknessByBone), "WeaknessByBone"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartForwardByBone"))
		{
			if (characterPartComponent.PartForwardByBone == null)
			{
				this.PartForwardByBone = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, string>>(this.PartForwardByBone), "PartForwardByBone"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GroupMapByBone"))
		{
			if (characterPartComponent.GroupMapByBone == null)
			{
				this.GroupMapByBone = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, string>>(this.GroupMapByBone), "GroupMapByBone"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartMapByCombineBone"))
		{
			if (characterPartComponent.PartMapByCombineBone == null)
			{
				this.PartMapByCombineBone = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, CharacterPart>>(this.PartMapByCombineBone), "PartMapByCombineBone"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartActiveTagChangeTaskList"))
		{
			if (characterPartComponent.PartActiveTagChangeTaskList == null)
			{
				this.PartActiveTagChangeTaskList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask[]>(this.PartActiveTagChangeTaskList), "PartActiveTagChangeTaskList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartComponentPb"))
		{
			if (characterPartComponent.PartComponentPb == null)
			{
				this.PartComponentPb = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PartComponentPb>(this.PartComponentPb), "PartComponentPb"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsMultiPartInternal"))
		{
			this.IsMultiPartInternal = characterPartComponent.IsMultiPartInternal;
		}
		return true;
	}

	// Token: 0x0400C97C RID: 51580
	public TsBaseCharacter BaseChar;

	// Token: 0x0400C97D RID: 51581
	public CharacterActorComponent ActorComp;

	// Token: 0x0400C97E RID: 51582
	public BaseTagComponent TagComponent;

	// Token: 0x0400C97F RID: 51583
	public UDataTable DtCharacterPart;

	// Token: 0x0400C980 RID: 51584
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public CharacterPart[] Parts;

	// Token: 0x0400C981 RID: 51585
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, CharacterPart> PartMapByBone;

	// Token: 0x0400C982 RID: 51586
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, CharacterPart> PartMapByTag;

	// Token: 0x0400C983 RID: 51587
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, CharacterPart> WeaknessByBone;

	// Token: 0x0400C984 RID: 51588
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, string> PartForwardByBone;

	// Token: 0x0400C985 RID: 51589
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, string> GroupMapByBone;

	// Token: 0x0400C986 RID: 51590
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, CharacterPart> PartMapByCombineBone;

	// Token: 0x0400C987 RID: 51591
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ITagTask[] PartActiveTagChangeTaskList;

	// Token: 0x0400C988 RID: 51592
	private PartComponentPb PartComponentPb;

	// Token: 0x0400C989 RID: 51593
	private bool IsMultiPartInternal;
}
