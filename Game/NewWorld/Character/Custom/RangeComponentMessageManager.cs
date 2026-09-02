using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.NewWorld.Character.Custom
{
	// Token: 0x020048E4 RID: 18660
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RangeComponentMessageManager : Singleton<RangeComponentMessageManager>
	{
		// Token: 0x06030AC4 RID: 199364 RVA: 0x00BFF401 File Offset: 0x00BFD601
		public RangeComponentMessageManager()
		{
			this.RegisterInfoMap.Clear();
		}

		// Token: 0x06030AC5 RID: 199365 RVA: 0x00BFF420 File Offset: 0x00BFD620
		public void RegisterMessage(Entity entity, AccessRangeType accessRangeType, AccessRangeResultType accessRangeResultType, TMessageRegisterCallback callback)
		{
			if (!this.RegisterInfoMap.ContainsKey(entity))
			{
				Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo> dictionary = new Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo>();
				MessageRegisterCallBackInfo messageRegisterCallBackInfo = new MessageRegisterCallBackInfo();
				switch (accessRangeType)
				{
				case AccessRangeType.RangeEnter:
					messageRegisterCallBackInfo.EnterCallbacks.Add(callback);
					break;
				case AccessRangeType.RangeLeave:
					messageRegisterCallBackInfo.LeaveCallback.Add(callback);
					break;
				case AccessRangeType.RangeInit:
					messageRegisterCallBackInfo.InitCallback.Add(callback);
					break;
				}
				dictionary[accessRangeResultType] = messageRegisterCallBackInfo;
				this.RegisterInfoMap[entity] = dictionary;
				return;
			}
			Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo> dictionary2 = this.RegisterInfoMap[entity];
			if (!dictionary2.ContainsKey(accessRangeResultType))
			{
				MessageRegisterCallBackInfo messageRegisterCallBackInfo2 = new MessageRegisterCallBackInfo();
				switch (accessRangeType)
				{
				case AccessRangeType.RangeEnter:
					messageRegisterCallBackInfo2.EnterCallbacks.Add(callback);
					break;
				case AccessRangeType.RangeLeave:
					messageRegisterCallBackInfo2.LeaveCallback.Add(callback);
					break;
				case AccessRangeType.RangeInit:
					messageRegisterCallBackInfo2.InitCallback.Add(callback);
					break;
				}
				dictionary2[accessRangeResultType] = messageRegisterCallBackInfo2;
				return;
			}
			MessageRegisterCallBackInfo messageRegisterCallBackInfo3 = dictionary2[accessRangeResultType];
			switch (accessRangeType)
			{
			case AccessRangeType.RangeEnter:
				messageRegisterCallBackInfo3.EnterCallbacks.Add(callback);
				return;
			case AccessRangeType.RangeLeave:
				messageRegisterCallBackInfo3.LeaveCallback.Add(callback);
				return;
			case AccessRangeType.RangeInit:
				messageRegisterCallBackInfo3.InitCallback.Add(callback);
				return;
			default:
				return;
			}
		}

		// Token: 0x06030AC6 RID: 199366 RVA: 0x00BFF54C File Offset: 0x00BFD74C
		public void UnRegisterMessage(Entity entity, AccessRangeType accessRangeType, AccessRangeResultType accessRangeResultType, TMessageRegisterCallback callback)
		{
			Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo> dictionary;
			MessageRegisterCallBackInfo messageRegisterCallBackInfo;
			if (this.RegisterInfoMap.TryGetValue(entity, out dictionary) && dictionary.TryGetValue(accessRangeResultType, out messageRegisterCallBackInfo))
			{
				switch (accessRangeType)
				{
				case AccessRangeType.RangeEnter:
					this.RemoveCallbackInternal(messageRegisterCallBackInfo.EnterCallbacks, callback);
					return;
				case AccessRangeType.RangeLeave:
					this.RemoveCallbackInternal(messageRegisterCallBackInfo.LeaveCallback, callback);
					return;
				case AccessRangeType.RangeInit:
					this.RemoveCallbackInternal(messageRegisterCallBackInfo.InitCallback, callback);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06030AC7 RID: 199367 RVA: 0x00BFF5B4 File Offset: 0x00BFD7B4
		private void RemoveCallbackInternal(List<TMessageRegisterCallback> allCallbacks, TMessageRegisterCallback needRemovedCallback)
		{
			int num = allCallbacks.IndexOf(needRemovedCallback);
			if (num != -1)
			{
				allCallbacks.RemoveAt(num);
			}
		}

		// Token: 0x06030AC8 RID: 199368 RVA: 0x00BFF5D4 File Offset: 0x00BFD7D4
		public bool HasMessage(Entity entity, AccessRangeType accessRangeType, AccessRangeResultType accessRangeResultType, TMessageRegisterCallback callback)
		{
			Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo> dictionary;
			MessageRegisterCallBackInfo messageRegisterCallBackInfo;
			if (this.RegisterInfoMap.TryGetValue(entity, out dictionary) && dictionary.TryGetValue(accessRangeResultType, out messageRegisterCallBackInfo))
			{
				switch (accessRangeType)
				{
				case AccessRangeType.RangeEnter:
					return messageRegisterCallBackInfo.EnterCallbacks.Contains(callback);
				case AccessRangeType.RangeLeave:
					return messageRegisterCallBackInfo.LeaveCallback.Contains(callback);
				case AccessRangeType.RangeInit:
					return messageRegisterCallBackInfo.InitCallback.Contains(callback);
				}
			}
			return false;
		}

		// Token: 0x06030AC9 RID: 199369 RVA: 0x00BFF63C File Offset: 0x00BFD83C
		public void EmitMessage(Entity entity, AccessRangeType accessRangeType, AccessRangeResultType accessRangeResultType, Entity otherEntity, ErrorCode errorCode)
		{
			Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo> dictionary;
			MessageRegisterCallBackInfo messageRegisterCallBackInfo;
			if (this.RegisterInfoMap.TryGetValue(entity, out dictionary) && dictionary.TryGetValue(accessRangeResultType, out messageRegisterCallBackInfo))
			{
				switch (accessRangeType)
				{
				case AccessRangeType.RangeEnter:
					using (List<TMessageRegisterCallback>.Enumerator enumerator = messageRegisterCallBackInfo.EnterCallbacks.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							TMessageRegisterCallback tmessageRegisterCallback = enumerator.Current;
							tmessageRegisterCallback(accessRangeType, accessRangeResultType, otherEntity, errorCode);
						}
						return;
					}
					break;
				case AccessRangeType.RangeLeave:
					break;
				case AccessRangeType.RangeInit:
					goto IL_A9;
				default:
					return;
				}
				using (List<TMessageRegisterCallback>.Enumerator enumerator = messageRegisterCallBackInfo.LeaveCallback.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						TMessageRegisterCallback tmessageRegisterCallback2 = enumerator.Current;
						tmessageRegisterCallback2(accessRangeType, accessRangeResultType, otherEntity, errorCode);
					}
					return;
				}
				IL_A9:
				foreach (TMessageRegisterCallback tmessageRegisterCallback3 in messageRegisterCallBackInfo.InitCallback)
				{
					tmessageRegisterCallback3(accessRangeType, accessRangeResultType, otherEntity, errorCode);
				}
			}
		}

		// Token: 0x0401BFA3 RID: 114595
		private readonly Dictionary<Entity, Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo>> RegisterInfoMap = new Dictionary<Entity, Dictionary<AccessRangeResultType, MessageRegisterCallBackInfo>>();
	}
}
