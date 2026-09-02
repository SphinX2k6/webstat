using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F85 RID: 20357
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonIndexData
	{
		// Token: 0x060348C6 RID: 215238 RVA: 0x00D2B798 File Offset: 0x00D29998
		[NullableContext(2)]
		public void RefreshSkillButtonIndex(EntityHandle entityHandle)
		{
			this.IsNormalButtonTypeList = false;
			BaseTagComponent component = entityHandle.Entity.GetComponent<BaseTagComponent>();
			int num = 0;
			foreach (int[] array in this.ButtonIndexTagIdList)
			{
				bool flag = true;
				foreach (int tagId in array)
				{
					if (!component.HasTag(tagId))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					this.ButtonTypeList = this.ButtonIndexTypeList[num];
					return;
				}
				num++;
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.ButtonTypeTagMap)
			{
				int key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				if (component.HasTag(key))
				{
					this.ButtonTypeList = value;
					return;
				}
			}
			this.ButtonTypeList = (this.ButtonIndexIsDesktop ? this.ButtonIndexConfig.Value.DesktopButtonTypeList() : this.ButtonIndexConfig.Value.PadButtonTypeList());
			this.IsNormalButtonTypeList = true;
		}

		// Token: 0x060348C7 RID: 215239 RVA: 0x00D2B8E4 File Offset: 0x00D29AE4
		[NullableContext(2)]
		public void RefreshSkillButtonIndexByTag(EntityHandle entityHandle, int tagId)
		{
			if (!this.IsNormalButtonTypeList)
			{
				this.RefreshSkillButtonIndex(entityHandle);
				return;
			}
			this.IsNormalButtonTypeList = false;
			if (this.ButtonIndexTagIdSet.Contains(tagId))
			{
				this.RefreshSkillButtonIndex(entityHandle);
				return;
			}
			List<int> buttonTypeList;
			if (this.ButtonTypeTagMap.TryGetValue(tagId, out buttonTypeList))
			{
				this.ButtonTypeList = buttonTypeList;
				return;
			}
			this.ButtonTypeList = (this.ButtonIndexIsDesktop ? this.ButtonIndexConfig.Value.DesktopButtonTypeList() : this.ButtonIndexConfig.Value.PadButtonTypeList());
			this.IsNormalButtonTypeList = true;
		}

		// Token: 0x060348C8 RID: 215240 RVA: 0x00D2B974 File Offset: 0x00D29B74
		public unsafe void UpdateSkillButtonIndexConfig(SkillButtonIndex? skillButtonIndexConfig, bool isDesktop)
		{
			int buttonIndexConfigId = this.ButtonIndexConfigId;
			int? num = (skillButtonIndexConfig != null) ? new int?(skillButtonIndexConfig.GetValueOrDefault().Id) : null;
			if ((buttonIndexConfigId == num.GetValueOrDefault() & num != null) && this.ButtonIndexIsDesktop == isDesktop)
			{
				return;
			}
			this.ButtonIndexConfig = skillButtonIndexConfig;
			this.ButtonIndexConfigId = ((this.ButtonIndexConfig != null) ? this.ButtonIndexConfig.GetValueOrDefault().Id : -1);
			this.ButtonIndexIsDesktop = isDesktop;
			this.ButtonIndexTagIdList.Clear();
			this.ButtonIndexTagIdSet.Clear();
			this.ButtonIndexTypeList.Clear();
			if (skillButtonIndexConfig == null)
			{
				return;
			}
			foreach (GameplayTagArray gameplayTagArray in skillButtonIndexConfig.Value.TagList())
			{
				List<int> list = new List<int>();
				int j = 0;
				while (j < gameplayTagArray.ArrayStringLength)
				{
					string text = gameplayTagArray.ArrayString(j);
					int? num2 = new int?(GameplayTagUtils.GetTagIdByName(text));
					if (num2 == null)
					{
						goto IL_141;
					}
					num = num2;
					int num3 = 0;
					if (num.GetValueOrDefault() == num3 & num != null)
					{
						goto IL_141;
					}
					list.Add(num2.Value);
					this.ButtonIndexTagIdSet.Add(num2.Value);
					IL_19F:
					j++;
					continue;
					IL_141:
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "技能按钮索引配置了不存在的Tag";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", text);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", this.ButtonIndexConfigId);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					goto IL_19F;
				}
				if (list.Count == 0)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.CFT;
					string message2 = "技能按钮索引组合Tag出现空元素，请确认改数组最后一个元素后面没有逗号";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ButtonIndexConfigId);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					break;
				}
				this.ButtonIndexTagIdList.Add(list.ToArray());
			}
			foreach (IntArray intArray in isDesktop ? skillButtonIndexConfig.Value.TagDesktopButtonTypeList() : skillButtonIndexConfig.Value.TagPadButtonTypeList())
			{
				List<int> list2 = new List<int>();
				for (int k = 0; k < intArray.ArrayIntLength; k++)
				{
					list2.Add(intArray.ArrayInt(k));
				}
				this.ButtonIndexTypeList.Add(list2);
			}
			if (this.ButtonIndexTagIdList.Count != this.ButtonIndexTypeList.Count)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Battle;
				ELogAuthor author3 = ELogAuthor.CFT;
				string message3 = "技能按钮索引组合Tag和按钮索引数组的数量不匹配";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", this.ButtonIndexConfigId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("TagLength", this.ButtonIndexTagIdList.Count);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("ButtonLength", this.ButtonIndexTypeList.Count);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			this.ButtonTypeTagMap.Clear();
			foreach (KeyValuePair<int, IntArray> keyValuePair in (isDesktop ? skillButtonIndexConfig.Value.DesktopButtonTypeMap() : skillButtonIndexConfig.Value.PadButtonTypeMap()))
			{
				int key = keyValuePair.Key;
				IntArray value = keyValuePair.Value;
				List<int> list3 = new List<int>();
				for (int l = 0; l < value.ArrayIntLength; l++)
				{
					list3.Add(value.ArrayInt(l));
				}
				this.ButtonTypeTagMap[key] = list3;
			}
		}

		// Token: 0x060348C9 RID: 215241 RVA: 0x00D2BD7C File Offset: 0x00D29F7C
		public void RefreshMotorPadSkillButtonIndex(EntityHandle entityHandle, bool isRoundJoystick)
		{
			this.IsRoundJoystick = isRoundJoystick;
			BaseTagComponent component = entityHandle.Entity.GetComponent<BaseTagComponent>();
			foreach (KeyValuePair<int, int[]> keyValuePair in (this.IsRoundJoystick ? this.MotorJoystickPadButtonTypeTagMap : this.MotorPadButtonTypeTagMap))
			{
				int num;
				int[] array;
				keyValuePair.Deconstruct(out num, out array);
				int tagId = num;
				int[] motorPadButtonTypeList = array;
				if (component.HasTag(tagId))
				{
					this.MotorPadButtonTypeList = motorPadButtonTypeList;
					break;
				}
			}
		}

		// Token: 0x060348CA RID: 215242 RVA: 0x00D2BE10 File Offset: 0x00D2A010
		public void InitMotorPadSkillButtonIndexConfig()
		{
			if (this.ButtonIndexConfig == null)
			{
				return;
			}
			this.MotorPadButtonTypeTagMap.Clear();
			this.MotorJoystickPadButtonTypeTagMap.Clear();
			foreach (KeyValuePair<int, IntArray> keyValuePair in this.ButtonIndexConfig.Value.MotorPadButtonTypeMap())
			{
				int num;
				IntArray intArray;
				keyValuePair.Deconstruct(out num, out intArray);
				int key = num;
				IntArray intArray2 = intArray;
				this.MotorPadButtonTypeTagMap[key] = intArray2.GetArrayIntBytes().ToArray();
			}
			foreach (KeyValuePair<int, IntArray> keyValuePair in this.ButtonIndexConfig.Value.MotorJoystickPadButtonTypeMap())
			{
				int num;
				IntArray intArray;
				keyValuePair.Deconstruct(out num, out intArray);
				int key2 = num;
				IntArray intArray3 = intArray;
				this.MotorJoystickPadButtonTypeTagMap[key2] = intArray3.GetArrayIntBytes().ToArray();
			}
		}

		// Token: 0x0401E476 RID: 124022
		public bool IsNormalButtonTypeList;

		// Token: 0x0401E477 RID: 124023
		public IList<int> ButtonTypeList = new List<int>();

		// Token: 0x0401E478 RID: 124024
		public SkillButtonIndex? ButtonIndexConfig;

		// Token: 0x0401E479 RID: 124025
		public int ButtonIndexConfigId = -1;

		// Token: 0x0401E47A RID: 124026
		public bool ButtonIndexIsDesktop;

		// Token: 0x0401E47B RID: 124027
		public readonly List<int[]> ButtonIndexTagIdList = new List<int[]>();

		// Token: 0x0401E47C RID: 124028
		public readonly HashSet<int> ButtonIndexTagIdSet = new HashSet<int>();

		// Token: 0x0401E47D RID: 124029
		public readonly List<List<int>> ButtonIndexTypeList = new List<List<int>>();

		// Token: 0x0401E47E RID: 124030
		public readonly Dictionary<int, List<int>> ButtonTypeTagMap = new Dictionary<int, List<int>>();

		// Token: 0x0401E47F RID: 124031
		public int[] MotorPadButtonTypeList = Array.Empty<int>();

		// Token: 0x0401E480 RID: 124032
		public bool IsRoundJoystick;

		// Token: 0x0401E481 RID: 124033
		public readonly Dictionary<int, int[]> MotorPadButtonTypeTagMap = new Dictionary<int, int[]>();

		// Token: 0x0401E482 RID: 124034
		public readonly Dictionary<int, int[]> MotorJoystickPadButtonTypeTagMap = new Dictionary<int, int[]>();
	}
}
