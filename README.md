# Blog Management System with ASP.NET CORE 7

Welcome to the Blog Management System, a collaborative effort built with ASP.NET Core 7 and Entity Framework. This project is the result of the combined efforts of two full stack development students currently enrolled in a course on Programming of Information Systems and Technologies.

**Collaborators:**

- [Fábio Gonçalves](https://github.com/fabi0wz)
- [Gonçalo Moreira](https://github.com/GoncaloJMM)

## Features

1. **User Registration and Authentication**
   - Users can register with the system, providing a secure way to manage their posts and interactions.
   - Authentication ensures secure access to user-specific functionalities.

2. **Profile Management**
   - Users have personal profiles where they can:
     - Change their profile picture.
     - Update their description.
     - Manage their password securely.

3. **Roles and Permissions**
   - Two roles are available: User and Admin.
   - Admins have additional capabilities, including:
     - Deleting users.
     - Changing user roles.
     - Deleting posts.

4. **Post Management**
   - Users can create, edit, and delete their own posts.
   - Admins have the authority to delete any post.
   - Posts track views to provide insights into their popularity.

5. **Comments and Likes**
   - Users can comment on and like other people's posts.
   - Foster engagement and interaction within the blogging community.

## Technology Stack

- **ASP.NET Core 7:** The framework that powers the backend.
- **Entity Framework:** For seamless data access and manipulation.
- **MVC Architecture:** A structured approach for a modular and scalable codebase.
- **Blazor Pages:** Used for the frontend to enhance interactivity.
- **Tailwind CSS:** A utility-first CSS framework for a modern and responsive design.

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/BlogManagementSystem.git
   ```

2. Navigate to the project directory:

    ```bash
   cd AspNetBlog
    ```

3. Open the solution in your preferred IDE (Visual Studio, VS Code, etc.).

4. Configure the database connection in the appsettings.json file:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "YourDatabaseConnectionString"
   }
   ```

## Contribution Guidelines
Contributions are welcome! If you find any issues or have ideas for improvements, please open an issue or create a pull request.
