using System.Collections;
using UnityEngine;
using TMPro;
using Firebase.Extensions;
using Firebase.Auth;
using Firebase;
using System.Collections.Generic;

public class EmailPassLogin : MonoBehaviour
{
    #region variables
    [Header("Login")]
    public TMP_InputField LoginEmail;
    public TMP_InputField loginPassword;

    [Header("Sign up")]
    public TMP_InputField SignupEmail;
    public TMP_InputField SignupPassword;
    public TMP_InputField SignupPasswordConfirm;

    [Header("Extra")]
    public GameObject loadingScreen;
    public TextMeshProUGUI logTxt;
    public GameObject loginUi, signupUi;
    #endregion


    #region signup 
    public void SignUp()
    {
        loadingScreen.SetActive(true);

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        string email = SignupEmail.text;
        string password = SignupPassword.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password)
            .ContinueWithOnMainThread(task =>
            {
                loadingScreen.SetActive(false);

                if (task.IsCanceled)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                    ShowLogMsg("Sign up failed!");
                    return;
                }

                AuthResult user = task.Result;
                Debug.Log("User created: " + user.User.UserId);

                SignupEmail.text = "";
                SignupPassword.text = "";
                SignupPasswordConfirm.text = "";

                DataSaver.Instance.userId = user.User.UserId;

                PlayerData defaultData = new PlayerData
                {
                    username = "Player_" + user.User.UserId.Substring(0, 5),
                    level = 1,
                    gold = 100,
                    part = 0,
                    inventory = new List<WeaponData>()
                };

                DataSaver.Instance.playerData = defaultData;
                DataSaver.Instance.SaveDataFn();
                ShowLogMsg("Please verify your email!");
                SendEmailVerification(user.User);
            });
    }


    public void SendEmailVerification(FirebaseUser user)
    {
        Debug.Log("SendEmailVerification called");
        StartCoroutine(SendEmailForVerificationAsync(user));
    }

    private IEnumerator SendEmailForVerificationAsync(FirebaseUser user)
    {
        Debug.Log("User email: " + user.Email);
        if (user != null)
        {
            Debug.Log("Sending email verification to " + user.Email);
            var sendEmailTask = user.SendEmailVerificationAsync();
            yield return new WaitUntil(() => sendEmailTask.IsCompleted);

            if (sendEmailTask.Exception != null)
            {
                print("Email send error");
                FirebaseException firebaseException = sendEmailTask.Exception.GetBaseException() as FirebaseException;
                AuthError error = (AuthError)firebaseException.ErrorCode;

                switch (error)
                {

                    case AuthError.None:
                        break;
                    case AuthError.Unimplemented:
                        break;
                    case AuthError.Failure:
                        break;
                    case AuthError.InvalidCustomToken:
                        break;
                    case AuthError.CustomTokenMismatch:
                        break;
                    case AuthError.InvalidCredential:
                        break;
                    case AuthError.UserDisabled:
                        break;
                    case AuthError.AccountExistsWithDifferentCredentials:
                        break;
                    case AuthError.OperationNotAllowed:
                        break;
                    case AuthError.EmailAlreadyInUse:
                        break;
                    case AuthError.RequiresRecentLogin:
                        break;
                    case AuthError.CredentialAlreadyInUse:
                        break;
                    case AuthError.InvalidEmail:
                        break;
                    case AuthError.WrongPassword:
                        break;
                    case AuthError.TooManyRequests:
                        break;
                    case AuthError.UserNotFound:
                        break;
                    case AuthError.ProviderAlreadyLinked:
                        break;
                    case AuthError.NoSuchProvider:
                        break;
                    case AuthError.InvalidUserToken:
                        break;
                    case AuthError.UserTokenExpired:
                        break;
                    case AuthError.NetworkRequestFailed:
                        break;
                    case AuthError.InvalidApiKey:
                        break;
                    case AuthError.AppNotAuthorized:
                        break;
                    case AuthError.UserMismatch:
                        break;
                    case AuthError.WeakPassword:
                        break;
                    case AuthError.NoSignedInUser:
                        break;
                    case AuthError.ApiNotAvailable:
                        break;
                    case AuthError.ExpiredActionCode:
                        break;
                    case AuthError.InvalidActionCode:
                        break;
                    case AuthError.InvalidMessagePayload:
                        break;
                    case AuthError.InvalidPhoneNumber:
                        break;
                    case AuthError.MissingPhoneNumber:
                        break;
                    case AuthError.InvalidRecipientEmail:
                        break;
                    case AuthError.InvalidSender:
                        break;
                    case AuthError.InvalidVerificationCode:
                        break;
                    case AuthError.InvalidVerificationId:
                        break;
                    case AuthError.MissingVerificationCode:
                        break;
                    case AuthError.MissingVerificationId:
                        break;
                    case AuthError.MissingEmail:
                        break;
                    case AuthError.MissingPassword:
                        break;
                    case AuthError.QuotaExceeded:
                        break;
                    case AuthError.RetryPhoneAuth:
                        break;
                    case AuthError.SessionExpired:
                        break;
                    case AuthError.AppNotVerified:
                        break;
                    case AuthError.AppVerificationFailed:
                        break;
                    case AuthError.CaptchaCheckFailed:
                        break;
                    case AuthError.InvalidAppCredential:
                        break;
                    case AuthError.MissingAppCredential:
                        break;
                    case AuthError.InvalidClientId:
                        break;
                    case AuthError.InvalidContinueUri:
                        break;
                    case AuthError.MissingContinueUri:
                        break;
                    case AuthError.KeychainError:
                        break;
                    case AuthError.MissingAppToken:
                        break;
                    case AuthError.MissingIosBundleId:
                        break;
                    case AuthError.NotificationNotForwarded:
                        break;
                    case AuthError.UnauthorizedDomain:
                        break;
                    case AuthError.WebContextAlreadyPresented:
                        break;
                    case AuthError.WebContextCancelled:
                        break;
                    case AuthError.DynamicLinkNotActivated:
                        break;
                    case AuthError.Cancelled:
                        break;
                    case AuthError.InvalidProviderId:
                        break;
                    case AuthError.WebInternalError:
                        break;
                    case AuthError.WebStorateUnsupported:
                        break;
                    case AuthError.TenantIdMismatch:
                        break;
                    case AuthError.UnsupportedTenantOperation:
                        break;
                    case AuthError.InvalidLinkDomain:
                        break;
                    case AuthError.RejectedCredential:
                        break;
                    case AuthError.PhoneNumberNotFound:
                        break;
                    case AuthError.InvalidTenantId:
                        break;
                    case AuthError.MissingClientIdentifier:
                        break;
                    case AuthError.MissingMultiFactorSession:
                        break;
                    case AuthError.MissingMultiFactorInfo:
                        break;
                    case AuthError.InvalidMultiFactorSession:
                        break;
                    case AuthError.MultiFactorInfoNotFound:
                        break;
                    case AuthError.AdminRestrictedOperation:
                        break;
                    case AuthError.UnverifiedEmail:
                        break;
                    case AuthError.SecondFactorAlreadyEnrolled:
                        break;
                    case AuthError.MaximumSecondFactorCountExceeded:
                        break;
                    case AuthError.UnsupportedFirstFactor:
                        break;
                    case AuthError.EmailChangeNeedsVerification:
                        break;
                    default:
                        break;
                }
                Debug.LogError("SendEmailVerificationAsync error: " + sendEmailTask.Exception);
            }
            else
            {
                Debug.Log("Email verification sent successfully.");
                print("Email successfully send");
            }
        }
    }


    #endregion

    #region Login
    public void Login()
    {
        loadingScreen.SetActive(true);

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        string email = LoginEmail.text;
        string password = loginPassword.text;

        Credential credential = EmailAuthProvider.GetCredential(email, password);

        auth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(task =>
        {
            loadingScreen.SetActive(false);

            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                ShowLogMsg("Login failed! Check email/password.");
                return;
            }

            FirebaseUser user = task.Result;
            Debug.Log("User signed in successfully: " + user.UserId);

            DataSaver.Instance.userId = user.UserId;

            if (user.IsEmailVerified)
            {
                DataSaver.Instance.LoadDataFn(() =>
                {
                    Debug.Log("Data load complete. Proceeding to next scene.");
                    loginUi.SetActive(false);
                    DataSaver.Instance.LoadNextScene();

                });
            }
            else
            {
                ShowLogMsg("Please verify email!!");
                SendEmailVerification(user);
                Debug.Log("Email is not verified.");
            }
        });
    }

    #endregion

    #region extra

    void ShowLogMsg(string msg)
    {
        StopCoroutine(nameof(FadeOutLog));
        logTxt.text = msg;
        logTxt.color = new Color(logTxt.color.r, logTxt.color.g, logTxt.color.b, 1f);
        float[] timings = new float[] { 5.0f, 1.0f };
        StartCoroutine(nameof(FadeOutLog), timings);
    }

    private IEnumerator FadeOutLog(object param)
    {
        float[] timings = (float[])param;
        float delay = timings[0];
        float fadeTime = timings[1];

        yield return new WaitForSeconds(delay);

        float timer = 0f;
        Color startColor = logTxt.color;

        while (timer < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
            logTxt.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        logTxt.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
    #endregion
}